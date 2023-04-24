using System.Threading.Tasks;
using FloppyBird.Core.Entities;
using UnityEngine;

namespace FloppyBird.Core.Drivers.Data.Repositories
{
    public interface IHighScoreRepository
    {
        Task<HighScoreEntity> GetHighestScoreAsync();
    }
}
