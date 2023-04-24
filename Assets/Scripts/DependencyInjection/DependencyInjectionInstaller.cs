using FloppyBird.Application.UseCases;
using FloppyBird.Core.Drivers.Physics;
using FloppyBird.Core.Events;
using FloppyBird.Core.EventSystem;
using FloppyBird.Presentation.InterfaceAdapters;
using Zenject;

namespace FloppyBird.DependencyInjection
{
    public class DependencyInjectionInstaller : MonoInstaller
    {
        public BirdMotor birdMotor; 
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<BirdDiedEvent>();
            
            Container
                .Bind<IBirdUseCase>()
                .To<BirdUseCase>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IBirdMotor>()
                .FromInstance(birdMotor)
                .AsSingle();

            Container
                .Bind<IEventChannel>()
                .To<EventChannel>()
                .AsSingle()
                .NonLazy();
        }
    }
}