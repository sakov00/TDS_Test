using _Project.Scripts.Enums;
using _Project.Scripts.GameObjects.UnitModels;
using _Project.Scripts.GameObjects.UnitViews;
using _Project.Scripts.Pools;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.GameObjects.UnitControllers
{
    public class RangeEnemyController : UnitController<RangeEnemyModel, RangeEnemyView>
    {
        [Inject] private EffectsPool _effectsPool;
        
        private ParticleSystem.Particle[] _particles = new ParticleSystem.Particle[1];
        private float _timeOffsetTakeDamage = 0.95f;
        
        public override void AttackAim()
        {
            base.AttackAim();
        }

        public override void MoveToAim()
        {
            base.MoveToAim();
        }
        
        public override async UniTask AttackAnimationEvent()
        {
            var effectModel = _effectsPool.Get(EffectType.AcidProjectile, Model.SpawnPointProjectile.position);
            effectModel.Effect.Play();
            
            await UniTask.Delay((int)(effectModel.Effect.main.duration * 1000f * _timeOffsetTakeDamage),
                cancellationToken: this.GetCancellationTokenOnDestroy());

            effectModel.Effect.GetParticles(_particles);
            var particle = _particles[0];
            
            var worldPos = effectModel.Effect.main.simulationSpace switch
            {
                ParticleSystemSimulationSpace.Local =>
                    effectModel.Effect.transform.TransformPoint(particle.position),

                ParticleSystemSimulationSpace.World =>
                    particle.position,

                ParticleSystemSimulationSpace.Custom =>
                    effectModel.Effect.main.customSimulationSpace.TransformPoint(particle.position),

                _ => particle.position
            };
            
            Model.Player.TakeDamage(worldPos);
        }
    }
}