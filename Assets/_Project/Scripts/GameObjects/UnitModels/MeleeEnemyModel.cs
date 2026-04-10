using System;
using UnityEngine;

namespace _Project.Scripts.GameObjects.UnitModels
{
    [Serializable]
    public class MeleeEnemyModel : UnitModel
    {
        [field:SerializeField] public Transform PointAttack;
    }
}