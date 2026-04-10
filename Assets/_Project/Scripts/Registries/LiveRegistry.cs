using System;
using System.Collections.Generic;
using _Project.Scripts.GameObjects.UnitControllers;
using UniRx;

namespace _Project.Scripts.Registries
{
    public class LiveRegistry
    {
        private readonly ReactiveCollection<UnitController> _liveObjects = new();

        public void Register(UnitController obj)
        {
            if (_liveObjects.Contains(obj)) return;
            _liveObjects.Add(obj);
        }

        public void Unregister(UnitController obj)
        {
            if (!_liveObjects.Contains(obj)) return; 
            _liveObjects.Remove(obj);
        }

        public ReactiveCollection<UnitController> GetAllReactive() => _liveObjects;
        
        public void GetAllByType<T>(List<T> result)
        {
            result.Clear();

            for (int i = 0; i < _liveObjects.Count; i++)
            {
                if (_liveObjects[i] is T t)
                    result.Add(t);
            }
        }

        public void Clear()
        {
            _liveObjects.Clear();
        }

        public IObservable<CollectionAddEvent<UnitController>> OnAddAsObservable() => _liveObjects.ObserveAdd();
        public IObservable<CollectionRemoveEvent<UnitController>> OnRemoveAsObservable() => _liveObjects.ObserveRemove();
    }
}