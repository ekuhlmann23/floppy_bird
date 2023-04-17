using System;

namespace FloppyBird.InterfaceAdapters.Input
{
    public interface IInputReader
    {
        public event Action BirdJumped;
    }
}
