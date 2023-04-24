using System;

namespace FloppyBird.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        { 
        }
    }
}
