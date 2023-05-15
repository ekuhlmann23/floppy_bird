using System;
using FloppyBird.Domain.Drivers;

namespace FloppyBird.Infrastructure.Drivers
{
    public class DummyDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.UnixEpoch;
        }
    }
}
