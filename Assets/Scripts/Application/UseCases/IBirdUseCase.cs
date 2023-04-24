using System;
using FloppyBird.Core.Entities;

namespace FloppyBird.Application.UseCases
{
    public interface IBirdUseCase
    {
        public void UpdateBirdPosition(float newYPosition);
        public void HandleJumpInput();
        public void HandleBirdCollision();
        public void Initialize(
            float flyForce,
            float yPosition,
            float deathZone);
    }
}

