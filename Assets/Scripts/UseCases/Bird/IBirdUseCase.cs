namespace FloppyBird.UseCases.Bird
{
    public interface IBirdUseCase
    {
        /// <summary>
        /// Makes the bird take damage. Handles bird death.
        /// </summary>
        public void TakeDamage();

        /// <summary>
        /// Makes the bird score points.
        /// <param name="points">Number of points to score.</param>
        /// </summary>
        public void ScorePoints(int points);

        /// <summary>
        /// Flaps the wings of the bird.
        /// </summary>
        public void FlapWings();

        /// <summary>
        /// Updates the YPosition of the bird, checking if the bird falls out of bounds.
        /// </summary>
        /// <param name="newYPosition">New YPosition.</param>
        public void UpdateYPosition(float newYPosition);
    }
}
