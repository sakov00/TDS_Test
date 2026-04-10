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

        private void OnValidate()
        {
            Effect ??= GetComponent<ParticleSystem>();
        }

        private void Awake()
        {
            InjectManager.Inject(this);
        }
        
        private void OnParticleSystemStopped()
        {
            _effectsPool.Return(this);
        }
    }
}