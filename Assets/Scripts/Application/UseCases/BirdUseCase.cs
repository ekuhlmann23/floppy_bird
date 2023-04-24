using System;
using FloppyBird.Core.Drivers.Physics;
using FloppyBird.Core.Entities;

namespace FloppyBird.Application.UseCases
{
    public class BirdUseCase : IBirdUseCase
    {
        private readonly BirdEntity _birdEntity;
        private readonly IBirdMotor _birdMotor;

        public event Action BirdDied;

        public BirdUseCase(BirdEntity birdEntity, IBirdMotor birdMotor)
        {
            _birdEntity = birdEntity;
            _birdMotor = birdMotor;
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
            BirdDied?.Invoke();
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

