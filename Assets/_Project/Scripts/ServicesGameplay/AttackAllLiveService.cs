using System.Collections.Generic;
using _Project.Scripts.Interfaces;
using _Project.Scripts.Registries;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts.ServicesGameplay
{
    public class AttackAllLiveService : ITickable
    {
        [Inject] private LiveRegistry _liveRegistry;
        
        private readonly List<ISimpleCharacter> _simpleCharacters = new();

        public void Tick()
        {
            _liveRegistry.GetAllByType(_simpleCharacters);

            for (int i = 0; i < _simpleCharacters.Count; i++)
            {
                HandleAttack(_simpleCharacters[i]);
            }
        }

        private void HandleAttack(ISimpleCharacter simpleCharacter)
        {
            if (simpleCharacter == null)
                return;

            var distance = Vector2.Distance(simpleCharacter.CurrentPosition, simpleCharacter.AimPosition);

            if (distance <= simpleCharacter.AttackRange)
            {
                simpleCharacter.AttackAim();
            }
            else
            {
                simpleCharacter.MoveToAim();
            }
        }
    }
}