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
        
        private int _delay = 150;
        
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
            var effectController = _effectsPool.Get(EffectType.AcidProjectile, Model.SpawnPointProjectile.position);
            effectController.Effect.Play();
            
            await UniTask.Delay((int)(effectController.Effect.main.duration * 1000f),
                cancellationToken: this.GetCancellationTokenOnDestroy());

            await UniTask.Delay(_delay);
            
            Model.Player.TakeDamage(effectController.LastPosition);
        }
    }
}