using System.Data;

namespace FloppyBird.Infrastructure.DataSources
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}
