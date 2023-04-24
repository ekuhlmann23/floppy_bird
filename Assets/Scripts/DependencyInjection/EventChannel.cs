using System;
using FloppyBird.Core.EventSystem;
using Zenject;

namespace FloppyBird.DependencyInjection
{
    public class EventChannel : IEventChannel
    {
        private readonly SignalBus _signalBus;

        public EventChannel(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void Subscribe<TEvent>(Action onEventRaised)
        {
            _signalBus.Subscribe<TEvent>(onEventRaised);
        }

        public void Unsubscribe<TEvent>(Action action)
        {
            _signalBus.Unsubscribe<TEvent>(action);
        }

        public void Raise<TEvent>()
        {
            _signalBus.Fire<TEvent>();
        }
    }
}