using System.Threading.Tasks;
using FloppyBird.Domain.Entities;

namespace FloppyBird.Domain.Repositories
{
    public interface IPlayerRepository
    {
        public Task<Player> GetPlayerWithScoresByNameAsync(string playerName);
    }
}
