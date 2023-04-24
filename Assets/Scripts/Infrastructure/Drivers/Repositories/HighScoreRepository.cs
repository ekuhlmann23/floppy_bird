using System.Threading.Tasks;
using Dapper;
using FloppyBird.Core.Drivers.Data.Repositories;
using FloppyBird.Core.Entities;
using FloppyBird.Infrastructure.Drivers.DataSources;

namespace FloppyBird.Infrastructure.Drivers.Repositories
{
    public class HighScoreRepository : IHighScoreRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public HighScoreRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<HighScoreEntity> GetHighestScoreAsync()
        {
            using var connection = _dbConnectionFactory.Create();
            return await connection.QueryFirstOrDefaultAsync<HighScoreEntity>(
                "select * from HighScores order by Score desc");
        }
    }
}