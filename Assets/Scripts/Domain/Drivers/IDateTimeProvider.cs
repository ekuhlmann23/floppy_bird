using System;

namespace FloppyBird.Domain.Drivers
{
    public interface IDateTimeProvider
    {
        public DateTime GetCurrentTime();
    }
}
