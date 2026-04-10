using _Project.Scripts._VContainer;
using _Project.Scripts.Pools;
using UnityEngine;
using VContainer;

namespace _Project.Scripts.Services
{
    public class PoolsManager : MonoBehaviour
    {
        [SerializeField] private Transform _effectsPoolContainer;
        
        [Inject] private EffectsPool _effectsPool;

        private void Start()
        {
            InjectManager.Inject(this);
            _effectsPool.SetContainer(_effectsPoolContainer);
        }
    }
}