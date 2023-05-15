using System;
using FloppyBird.Domain.Drivers;

namespace FloppyBird.Infrastructure.Drivers
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
