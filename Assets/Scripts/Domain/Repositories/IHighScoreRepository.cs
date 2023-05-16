using System.Threading.Tasks;
using FloppyBird.Domain.Entities;

namespace FloppyBird.Domain.Repositories
{
    public interface IHighScoreRepository
    {
        public int GetHighestScore();
    }
}
