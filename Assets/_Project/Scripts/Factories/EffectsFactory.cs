using System.Linq;
using _Project.Scripts.Enums;
using _Project.Scripts.GameObjects;
using _Project.Scripts.SO;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.Factories
{
    public class EffectsFactory
    {
        [Inject] private IObjectResolver _resolver;
        [Inject] private EffectsConfig _effectsConfig;
        
        public EffectController CreateEffect(EffectType effectType, Vector3 position = default, Quaternion rotation = default)
        {
            var prefab = _effectsConfig.EffectsList
                .FirstOrDefault(p => p.EffectType == effectType);

            return prefab != null ? _resolver.Instantiate(prefab, position, rotation) : null;
        }
    }
}