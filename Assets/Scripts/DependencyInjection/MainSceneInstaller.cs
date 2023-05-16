using FloppyBird.Application.UseCases;
using FloppyBird.Domain.Drivers;
using FloppyBird.Domain.Events;
using FloppyBird.Domain.EventSystem;
using FloppyBird.Domain.Repositories;
using FloppyBird.Infrastructure.DataSources;
using FloppyBird.Infrastructure.Drivers;
using FloppyBird.Infrastructure.EventSystem;
using FloppyBird.Infrastructure.Repositories;
using UnityEngine;
using Zenject;

namespace FloppyBird.DependencyInjection
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterEventSystem();
            
            DeclareGameEvents();
            
            Container
                .Bind<IBirdUseCase>()
                .To<BirdUseCase>()
                .AsSingle();

            Container.Bind<IHighScoreRepository>()
                .To<HighScoresRepository>()
                .AsSingle();

            Container.Bind<IEnvironmentManager>()
                .To<EnvironmentManager>()
                .AsSingle();

            Container.Bind<IDbConnectionFactory>()
                .To<SqlServerDbConnectionFactory>()
                .AsSingle();

            Container.Bind<IDateTimeProvider>()
                .To<DummyDateTimeProvider>()
                .AsSingle();

            Container.Bind<IPlayerRepository>()
                .To<PlayerRepository>()
                .AsSingle();

            Container.Bind<IPlayerScoresUseCase>()
                .To<PlayerScoresUseCase>()
                .AsSingle();
        }

        private void DeclareGameEvents()
        {
            Container.DeclareSignal<BirdDiedEvent>();
        }

        private void RegisterEventSystem()
        {
            SignalBusInstaller.Install(Container);
            Container.Bind<IEventChannel>()
                .To<SignalEventChannel>()
                .AsSingle()
                .NonLazy();
        }
    }
}
