namespace FloppyBird.Entities
{
    public class PipeEntity : BaseEntity
    {
        public PipeEntity(float xPosition, float yPosition, float movementSpeed, float deathZone)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            MovementSpeed = movementSpeed;
            DeathZone = deathZone;
        }

        public float XPosition { get; private set; }
        public float YPosition { get; private set; }
        public float MovementSpeed { get; private set; }
        public float DeathZone { get; private set; }

        /// <summary>
        /// Updates the position of the object, checking whether it should be destroyed or not.
        /// </summary>
        /// <param name="deltaTime">Time since last update.</param>
        /// <returns></returns>
        public bool UpdatePosition(float deltaTime)
        {
            // Negative because we move to the left.
            // We use P_f = P_i + vt.
            XPosition -= -MovementSpeed * deltaTime;

            return XPosition < DeathZone;
        }
    }
}
