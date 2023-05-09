using FloppyBird.Domain.InterfaceAdapters;

namespace FloppyBird.Application.UseCases
{
    public interface IBirdUseCase
    {
        /// <summary>
        /// Initialized the use case class by instantiating a bird entity.
        /// </summary>
        /// <param name="birdMovement">Motor to move bird.</param>
        /// <param name="flyForce">The entity's fly force.</param>
        /// <param name="yPosition">The entity's vertical position.</param>
        /// <param name="deathZone">The entity's vertical kill threshold.</param>
        public void Initialize(IBirdMovement birdMovement, float flyForce,float yPosition, float deathZone);

        /// <summary>
        /// Updates the bird's vertical position.
        /// </summary>
        /// <param name="newYPosition">The new y position.</param>
        public void UpdateBirdPosition(float newYPosition);

        /// <summary>
        /// Handles the bird's jump event. 
        /// </summary>
        public void BirdJump();

        /// <summary>
        /// Handles the bird's collision.
        /// </summary>
        public void BirdCollide();
    }
}
