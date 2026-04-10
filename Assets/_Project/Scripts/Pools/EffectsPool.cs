using System.Collections.Generic; 
using System.Linq;
using _Project.Scripts.Enums;
using _Project.Scripts.Factories;
using _Project.Scripts.GameObjects;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.Pools
{
    public class EffectsPool
    {
        [Inject] private EffectsFactory _effectsFactory;
        
        private Transform _containerTransform;
        private readonly List<EffectController> _availableEffects = new();

        public void SetContainer(Transform transform)
        {
            _containerTransform = transform;
        }
        
        public EffectController Get(EffectType effectType, Vector3 position = default, Quaternion rotation = default) 
        {
            var build = _availableEffects.FirstOrDefault(c => c.EffectType == effectType);
            if (build != null)
            {
                _availableEffects.Remove(build);
                build.transform.position = position;
                build.transform.rotation = rotation;
                build.gameObject.SetActive(true);
            }
            else
            {
                build = _effectsFactory.CreateEffect(effectType, position, rotation);
            }

            build.transform.SetParent(null);
            return build;
        }

        public void Return(EffectController effect)
        {
            if (!_availableEffects.Contains(effect))
            {
                _availableEffects.Add(effect);
            }
            
            effect.gameObject.SetActive(false);
            effect.transform.SetParent(_containerTransform, false); 
        }
        
        public void Remove(EffectController effect)
        {
            if (!_availableEffects.Contains(effect))
            {
                _availableEffects.Remove(effect);
            }
        }
    }
}