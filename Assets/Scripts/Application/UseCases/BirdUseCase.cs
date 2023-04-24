using FloppyBird.Domain.Entities;

namespace FloppyBird.Application.UseCases
{
    public class BirdUseCase : IBirdUseCase
    {
        private BirdEntity _birdEntity;

        public void Initialize(float flyForce, float yPosition, float deathZone)
        {
            _birdEntity = new(flyForce, yPosition, deathZone);
        }

        public bool UpdateBirdPosition(float newYPosition)
        {
            return _birdEntity.UpdateYPosition(newYPosition);
        }

        public bool TryBirdJump(out float flyForce)
        {
            return _birdEntity.TryJump(out flyForce);
        }

        public bool BirdCollide()
        {
            return _birdEntity.TryKill();
        }
    }
}
