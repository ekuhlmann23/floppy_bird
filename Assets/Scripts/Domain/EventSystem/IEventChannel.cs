using System;

namespace FloppyBird.Domain.EventSystem
{
    public interface IEventChannel
    {
        public void Raise<TEvent>(TEvent eventToRaise)
            where TEvent : IEvent;
        
        public void Subscribe<TEvent>(Action<TEvent> eventCallback)
            where TEvent : IEvent;
        
        public void Unsubscribe<TEvent>(Action<TEvent> eventCallback)
            where TEvent : IEvent;
    }
}