using _Project.Scripts.Factories;
using _Project.Scripts.Pools;
using _Project.Scripts.Registries;
using _Project.Scripts.Services;
using _Project.Scripts.ServicesGameplay;
using _Project.Scripts.SO;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Project.Scripts._VContainer
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] protected PoolsManager _poolsManager;
        
        [Header("Configs")]
        [SerializeField] protected EffectsConfig _effectsConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(InjectManager.Initialize);
            
            RegisterRegistries(builder);
            RegisterPools(builder);
            RegisterFactories(builder);
            RegisterSO(builder);
            RegisterServices(builder);
        }
        
        private void RegisterRegistries(IContainerBuilder builder)
        {
            builder.Register<LiveRegistry>(Lifetime.Singleton).AsSelf();
        }
        
        private void RegisterPools(IContainerBuilder builder)
        {
            builder.Register<EffectsPool>(Lifetime.Singleton).AsSelf();
        }
        
        private void RegisterFactories(IContainerBuilder builder)
        {
            builder.Register<EffectsFactory>(Lifetime.Singleton).AsSelf();
        }
        
        private void RegisterSO(IContainerBuilder builder)
        {
            builder.RegisterInstance(_effectsConfig).AsSelf();
        }
        
        private void RegisterServices(IContainerBuilder builder)
        {
            builder.RegisterInstance(_poolsManager).AsSelf();
            
            builder.Register<AttackAllLiveService>(Lifetime.Singleton).AsSelf();
            
            builder.Register<TickScheduler>(Lifetime.Singleton).AsSelf().As<ITickable>();
        }
    }
}