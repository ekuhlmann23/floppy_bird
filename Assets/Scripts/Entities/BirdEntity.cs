using System;

namespace FloppyBird.Entities
{
    public class BirdEntity : BaseEntity
    {
        public float YPosition { get; private set; }
        public float FlyForce { get; private set; }
        public float DeathZone { get; private set; }
        public bool IsBirdAlive { get; private set; }

        public bool IsBirdDead => !IsBirdAlive;

        public BirdEntity(float yPosition, float flyForce, float deathZone)
        {
            FlyForce = flyForce;
            DeathZone = deathZone;
            IsBirdAlive = true;
        }

        /// <summary>
        /// Kills the bird if it is not already dead.
        /// </summary>
        /// <returns>True if the bird was killed, false if it was already dead.</returns>
        private bool TryKill()
        {
            if (IsBirdDead)
            {
                return false;
            }

            IsBirdAlive = false;
            return true;
        }

        /// <summary>
        /// Updates <see cref="YPosition"/> and determines whether it is valid.
        /// </summary>
        /// <param name="newYPosition"></param>
        /// <returns></returns>
        public bool UpdateYPosition(float newYPosition)
        {
            YPosition = newYPosition;
            return IsDeathZoneCrossed();
        }

        private bool IsDeathZoneCrossed()
        {
            return IsBirdAlive && Math.Abs(YPosition) > Math.Abs(DeathZone);
        }

        public bool CanScorePoint() => IsBirdAlive;

        public bool TakeDamage() => TryKill();

        public float FlapWings() => FlyForce;
    }
}
