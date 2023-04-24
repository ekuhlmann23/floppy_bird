using System;

namespace FloppyBird.Core.EventSystem
{
    public interface IEventChannel
    {
        public void Subscribe<TEvent>(Action onEventRaised);
        public void Unsubscribe<TEvent>(Action onEventRaised);
        public void Raise<TEvent>();
    }
}