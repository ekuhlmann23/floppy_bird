using System.Data;
using System.Data.SqlClient;
using FloppyBird.Domain.Drivers;

namespace FloppyBird.Infrastructure.DataSources
{
    public class SqlServerDbConnectionFactory : IDbConnectionFactory
    {
        private const string ConnectionStringEnvironmentVariable = "CONNECTION_STRING";
        
        private readonly IEnvironmentManager _environmentManager;

        public SqlServerDbConnectionFactory(IEnvironmentManager environmentManager)
        {
            _environmentManager = environmentManager;
        }
        
        public IDbConnection Create()
        {
            var connectionString = _environmentManager.GetEnvironmentVariable(ConnectionStringEnvironmentVariable);
            return new SqlConnection(connectionString);
        }
    }
}
