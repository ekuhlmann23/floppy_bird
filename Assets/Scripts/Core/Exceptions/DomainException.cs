using System;

namespace FloppyBird.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        { 
        }
    }
}

