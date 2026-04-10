using System;
using UnityEngine;

namespace _Project.Scripts.GameObjects.UnitViews
{
    [Serializable]
    public abstract class UnitView
    {
        private static readonly int IsMove = Animator.StringToHash("IsMove");
        private static readonly int IsAttack = Animator.StringToHash("IsAttack");

        [SerializeField] private Animator _animator;
        
        public void Initialize()
        {
        }

        public virtual void SetMoving(bool isWalking)
        {
            if (_animator == null) return;

            if (isWalking)
            {
                if (_animator.GetBool(IsAttack))
                    _animator.SetBool(IsAttack, false);
            }

            if (_animator.GetBool(IsMove) == isWalking)
                return;

            _animator.SetBool(IsMove, isWalking);
        }

        public virtual void SetAttacking(bool isAttacking)
        {
            if (_animator == null) return;

            if (isAttacking)
            {
                if (_animator.GetBool(IsMove))
                    _animator.SetBool(IsMove, false);
            }

            if (_animator.GetBool(IsAttack) == isAttacking)
                return;

            _animator.SetBool(IsAttack, isAttacking);
        }
    }
}
