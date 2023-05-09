using System;

namespace FloppyBird.Domain.InterfaceAdapters.Input
{
    public interface IInputReader
    {
        public event Action BirdJump;
    }
}