using System;
using System.Data;
using System.Data.SqlClient;
using UnityEditor.MemoryProfiler;

namespace FloppyBird.Infrastructure.Drivers.DataSources
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private const string ConnectionStringEnvironmentVariable = "CONNECTION_STRING"; 
        
        public IDbConnection Create()
        {
            var connectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariable);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No connection string has been configured in the environment.");
            }
            
            return new SqlConnection(connectionString!);
        }
    }
}