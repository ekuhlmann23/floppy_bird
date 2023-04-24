using System;
using FloppyBird.Core.Drivers.Physics;
using FloppyBird.Core.Entities;
using FloppyBird.Core.Events;
using FloppyBird.Core.EventSystem;

namespace FloppyBird.Application.UseCases
{
    public class BirdUseCase : IBirdUseCase
    {
        private readonly IEventChannel _eventChannel;
        private readonly IBirdMotor _birdMotor;
        
        private BirdEntity _birdEntity;

        public BirdUseCase(IEventChannel eventChannel, IBirdMotor birdMotor)
        {
            _eventChannel = eventChannel;
            _birdMotor = birdMotor;
        }

        public void Initialize(
            float flyForce,
            float yPosition,
            float deathZone)
        {
            _birdEntity = new(flyForce, yPosition, deathZone);
        }

        public void HandleBirdCollision()
        {
            if (_birdEntity.TryKill())
            {
                TriggerBirdDeath();
            }
        }

        private void TriggerBirdDeath()
        {
            _eventChannel.Raise<BirdDiedEvent>();
        }

        public void HandleJumpInput()
        {
            if (_birdEntity.TryJump(out float flyForce))
            {
                _birdMotor.UpdateVerticalVelocity(flyForce);
            }
        }

        public void UpdateBirdPosition(float newYPosition)
        {
            bool birdFellOutOfBounds = _birdEntity.UpdateYPosition(newYPosition);
            if (birdFellOutOfBounds)
            {
                TriggerBirdDeath();
            }
        }
    }
}

