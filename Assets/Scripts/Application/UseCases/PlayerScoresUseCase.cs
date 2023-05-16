using System.Threading.Tasks;
using FloppyBird.Domain.Entities;
using FloppyBird.Domain.Repositories;

namespace FloppyBird.Application.UseCases
{
    public class PlayerScoresUseCase : IPlayerScoresUseCase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerScoresUseCase(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Task<Player> LoadPlayerWithScoresAsync(string playerName)
        {
            return _playerRepository.GetPlayerWithScoresByNameAsync(playerName);
        }
    }
}
