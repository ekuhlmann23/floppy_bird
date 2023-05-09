using FloppyBird.Domain.Entities;
using FloppyBird.Domain.Events;
using FloppyBird.Domain.EventSystem;
using FloppyBird.Domain.InterfaceAdapters;

namespace FloppyBird.Application.UseCases
{
    public class BirdUseCase : IBirdUseCase
    {
        private readonly IEventChannel _eventChannel;
        
        private BirdEntity _birdEntity;
        private IBirdMovement _birdMovement;

        public BirdUseCase(IEventChannel eventChannel)
        {
            _eventChannel = eventChannel;
        }

        public void Initialize(IBirdMovement birdMovement, float flyForce, float yPosition, float deathZone)
        {
            _birdMovement = birdMovement;
            _birdEntity = new(flyForce, yPosition, deathZone);
        }

        public void UpdateBirdPosition(float newYPosition)
        {
            if (_birdEntity.UpdateYPosition(newYPosition))
            {
                NotifyBirdDied();
            }
        }

        private void NotifyBirdDied()
        {
            _eventChannel.Raise(new BirdDiedEvent());
        }

        public void BirdJump()
        {
            if (_birdEntity.TryJump(out float flyForce))
            {
                _birdMovement.SetUpwardsVelocity(flyForce); 
            }
        }

        public void BirdCollide()
        {
            if (_birdEntity.TryKill())
            {
                NotifyBirdDied();
            }
        }
    }
}
