using Dapper;
using FloppyBird.Domain.Entities;
using FloppyBird.Domain.Repositories;
using FloppyBird.Infrastructure.DataSources;

namespace FloppyBird.Infrastructure.Repositories
{
    public class HighScoresRepository : IHighScoreRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public HighScoresRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public int GetHighestScore()
        {
            using var connection = _connectionFactory.Create();
            var result = connection.QueryFirstOrDefault<HighScoreEntity>("select * from HighScores order by Score desc");

            return result.Score;
        }
    }
}
