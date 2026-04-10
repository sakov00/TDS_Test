using System;
using _Project.Scripts._VContainer;
using _Project.Scripts.Enums;
using _Project.Scripts.Pools;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

public class PlayerController : MonoBehaviour
{
    [Inject] private EffectsPool _effectsPool;

    protected virtual void Awake()
    {
        InjectManager.Inject(this);
    }

    public void TakeDamage(Vector2 attackPosition)
    {
        var effectModel = _effectsPool.Get(EffectType.WoodHitEffect, attackPosition);
        effectModel.Effect.Play();
    }
}