using FloppyBird.Application.UseCases;
using FloppyBird.Domain.Repositories;
using FloppyBird.Infrastructure.DataSources;
using FloppyBird.Infrastructure.Repositories;
using UnityEngine;
using Zenject;

namespace FloppyBird.DependencyInjection
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IBirdUseCase>()
                .To<BirdUseCase>()
                .AsSingle();

            Container.Bind<IHighScoreRepository>()
                .To<HighScoresRepository>()
                .AsSingle();

            Container.Bind<IDbConnectionFactory>()
                .To<SqlServerDbConnectionFactory>()
                .AsSingle();
        }
    }
}
