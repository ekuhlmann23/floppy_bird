using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FloppyBird.Domain.Entities;
using FloppyBird.Domain.Repositories;
using FloppyBird.Infrastructure.DataSources;

namespace FloppyBird.Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PlayerRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Player> GetPlayerWithScoresByNameAsync(string playerName)
        {
            using var connection = _connectionFactory.Create();
            var players = await connection.QueryAsync<Player, HighScoreEntity, Player>(
                sql: "SELECT * FROM Players p INNER JOIN HighScores s on p.Name = s.PlayerName WHERE p.Name = @PlayerName",
                map: (player, highScore) =>
                {
                    player.AddScore(highScore);
                    return player;
                },
                splitOn: "Id",
                param: new { PlayerName = playerName });

            return players.FirstOrDefault();
        }

        // Other query examples:
        public async Task<IEnumerable<Player>> GetAllPlayerWithScoresAsync()
        {
            using var connection = _connectionFactory.Create();
            var players = await connection.QueryAsync<Player, HighScoreEntity, Player>(
                sql: "SELECT * FROM Players p INNER JOIN HighScores s on p.Name = s.PlayerName",
                map: (player, highScore) =>
                {
                    player.AddScore(highScore);
                    return player;
                },
                splitOn: "Id");

            return players;
        }

        public async Task<IEnumerable<Player>> GetAllPlayerAsync()
        {
            using var connection = _connectionFactory.Create();
            var players = await connection.QueryAsync<Player>(
                sql: "SELECT * FROM Players p");

            return players;
        }
    }
}
