using UnityEngine;

namespace _Project.Scripts.Interfaces
{
    public interface ISimpleCharacter
    {
        Vector3 CurrentPosition { get; }
        Vector3 AimPosition { get; }
        float AttackRange { get; }
        void AttackAim();
        void MoveToAim();
    }
}