using System;
using FloppyBird.Domain.EventSystem;
using Zenject;

namespace FloppyBird.Infrastructure.EventSystem
{
    public class SignalEventChannel : IEventChannel
    {
        private readonly SignalBus _signalBus;

        public SignalEventChannel(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Raise<TEvent>(TEvent eventToRaise) where TEvent : IEvent
        {
            _signalBus.Fire(eventToRaise);
        }

        public void Subscribe<TEvent>(Action<TEvent> eventCallback) where TEvent : IEvent
        {
            _signalBus.Subscribe(eventCallback);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> eventCallback) where TEvent : IEvent
        {
            _signalBus.Unsubscribe(eventCallback);
        }
    }
}