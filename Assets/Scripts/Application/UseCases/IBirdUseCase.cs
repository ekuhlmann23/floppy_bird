namespace FloppyBird.Application.UseCases
{
    public interface IBirdUseCase
    {
        /// <summary>
        /// Initialized the use case class by instantiating a bird entity.
        /// </summary>
        /// <param name="flyForce">The entity's fly force.</param>
        /// <param name="yPosition">The entity's vertical position.</param>
        /// <param name="deathZone">The entity's vertical kill threshold.</param>
        public void Initialize(float flyForce,float yPosition, float deathZone);

        /// <summary>
        /// Updates the bird's vertical position.
        /// </summary>
        /// <param name="newYPosition">The new y position.</param>
        /// <returns>Whether the bird is out of bounds.</returns>
        public bool UpdateBirdPosition(float newYPosition);

        /// <summary>
        /// Handles the bird's jump event. 
        /// </summary>
        /// <param name="flyForce">Out variable where the upwards fly velocity is stored.</param>
        /// <returns>Whether the bird should be able to jump.</returns>
        public bool TryBirdJump(out float flyForce);

        /// <summary>
        /// Handles the bird's collision.
        /// </summary>
        /// <returns>Whether the bird died due to the collision.</returns>
        public bool BirdCollide();
    }
}
