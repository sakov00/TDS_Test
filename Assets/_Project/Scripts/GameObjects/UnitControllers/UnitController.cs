using _Project.Scripts._VContainer;
using _Project.Scripts.GameObjects.UnitModels;
using _Project.Scripts.GameObjects.UnitViews;
using _Project.Scripts.Interfaces;
using _Project.Scripts.Registries;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.GameObjects.UnitControllers
{
    public abstract class UnitController<TModel, TView> : UnitController
        where TModel : UnitModel
        where TView : UnitView 
    {
        protected new TModel Model => (TModel)base.Model;
        protected new TView View => (TView)base.View;
    }
    
    public abstract class UnitController : MonoBehaviour, ISimpleCharacter
    {
        [Inject] protected LiveRegistry LiveRegistry;
        
        [SerializeReference, SubclassSelector]
        private UnitModel _model;
        
        [SerializeReference, SubclassSelector]
        private UnitView _view;

        public Vector3 CurrentPosition => transform.position;
        public Vector3 AimPosition => _model.Player.transform.position;
        public float AttackRange => _model.RangeAttack;

        public UnitModel Model
        {
            get { return _model; } 
            set { _model = value; }
        }
    
        public UnitView View
        {
            get { return _view; } 
            set { _view = value; }
        }
        
        protected virtual void Awake()
        {
            InjectManager.Inject(this);
            Initialize();
        }
        
        public virtual void Initialize()
        {
            LiveRegistry.Register(this);
        }
        
        public virtual void AttackAim()
        {
            View.SetMoving(false);
            View.SetAttacking(true);
        }

        public virtual void MoveToAim()
        {
            transform.position += Vector3.left * _model.MoveSpeed * Time.deltaTime;
            View.SetAttacking(false);
            View.SetMoving(true);
        }

        public abstract UniTask AttackAnimationEvent();
    }
}