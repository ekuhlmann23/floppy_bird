using System.Data;

namespace FloppyBird.Infrastructure.Drivers.DataSources
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}