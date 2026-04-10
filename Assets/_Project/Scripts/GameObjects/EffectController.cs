using System;
using _Project.Scripts._VContainer;
using _Project.Scripts.Enums;
using _Project.Scripts.Pools;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.GameObjects
{
    public class EffectController : MonoBehaviour
    {
        [Inject] private EffectsPool _effectsPool;
        
        public EffectType EffectType;
        public ParticleSystem Effect;
        public Vector3 LastPosition { get; private set; }
        
        private ParticleSystem.Particle[] _particles = new ParticleSystem.Particle[1];

        private void OnValidate()
        {
            Effect ??= GetComponent<ParticleSystem>();
        }

        private void Awake()
        {
            InjectManager.Inject(this);
        }

        private void LateUpdate()
        {
            Effect.GetParticles(_particles);
            var particle = _particles[0];
            
            var worldPos = Effect.main.simulationSpace switch
            {
                ParticleSystemSimulationSpace.Local =>
                    Effect.transform.TransformPoint(particle.position),

                ParticleSystemSimulationSpace.World =>
                    particle.position,

                ParticleSystemSimulationSpace.Custom =>
                    Effect.main.customSimulationSpace.TransformPoint(particle.position),

                _ => particle.position
            };
            LastPosition = worldPos;
        }

        private void OnParticleSystemStopped()
        {
            _effectsPool.Return(this);
        }
    }
}