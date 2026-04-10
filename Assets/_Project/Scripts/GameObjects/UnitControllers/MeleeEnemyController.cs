using _Project.Scripts.GameObjects.UnitModels;
using _Project.Scripts.GameObjects.UnitViews;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.GameObjects.UnitControllers
{
    public class MeleeEnemyController : UnitController<MeleeEnemyModel, MeleeEnemyView>
    {
        public override void AttackAim()
        {
            base.AttackAim();
        }

        public override void MoveToAim()
        {
            base.MoveToAim();
        }

        public override UniTask AttackAnimationEvent()
        {
            Model.Player.TakeDamage(Model.PointAttack.position);
            return UniTask.CompletedTask;
        }
    }
}