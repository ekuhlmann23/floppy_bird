using System.Threading.Tasks;
using FloppyBird.Domain.Entities;

namespace FloppyBird.Application.UseCases
{
    public interface IPlayerScoresUseCase
    {
        public Task<Player> LoadPlayerWithScoresAsync(string playerName);
        //public Task AddScoreToPlayerAsync(Player player, HighScoreEntity highScore);
    }
}
