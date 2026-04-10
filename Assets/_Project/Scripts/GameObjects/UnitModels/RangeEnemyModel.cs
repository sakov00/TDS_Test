using System;
using UnityEngine;

namespace _Project.Scripts.GameObjects.UnitModels
{
    [Serializable]
    public class RangeEnemyModel : UnitModel
    {
        [field:SerializeField] public Transform SpawnPointProjectile;
    }
}