using System;
using System.Data;
using System.Data.SqlClient;

namespace FloppyBird.Infrastructure.DataSources
{
    public class SqlServerDbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection Create()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FloppyBIrd.Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
        }
    }
}
