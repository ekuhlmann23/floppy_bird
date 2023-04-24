using System;

namespace FloppyBird.Drivers.Input
{
    public interface IInputReader
    {
        public event Action BirdJumped;
    }
}
