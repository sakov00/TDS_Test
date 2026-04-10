using System;
using System.Collections.Generic;
using _Project.Scripts.Enums;
using _Project.Scripts.GameObjects;
using UnityEngine;

namespace _Project.Scripts.SO
{
    [CreateAssetMenu(fileName = "EffectsConfig", menuName = "SO/Effects Config")]
    public class EffectsConfig : ScriptableObject
    {
        [SerializeField] public List<EffectController> EffectsList = new();
    }
}