using System;
using UnityEngine;

namespace _Project.Scripts.GameObjects.UnitModels
{
    [Serializable]
    public abstract class UnitModel
    {
        [field: Header("Constant Aim")] 
        [field: SerializeField] public PlayerController Player;
        
        [field: Header("Unit Data")] 
        [field: SerializeField] public float RangeAttack;
        [field: SerializeField] public float MoveSpeed;
    }
}