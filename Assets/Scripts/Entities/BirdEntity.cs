using System;
public class BirdEntity
{
	public bool IsAlive { get; private set; }
	public float FlyForce { get; private set; }
	public float YPosition { get; private set; }
	public float DeathZone { get; private set; }

    public bool IsDead => !IsAlive;

    /// <summary>
    /// Constructs a bird entity with the required properties.
    /// <remarks>By default, every bird is alive on creation.</remarks> 
    /// </summary>
    /// <param name="flyForce">Upwards velocity change when jumping.</param>
    /// <param name="yPosition">Initial vertical position.</param>
    /// <param name="deathZone">Out of bounds vertical threshold.</param>
    /// <exception cref="DomainException">When the bird is created out of bounds.</exception>
    public BirdEntity(
		float flyForce,
		float yPosition,
		float deathZone)
    {
        FlyForce = flyForce;
        YPosition = yPosition;
        DeathZone = deathZone;

        if (IsOutOfBounds())
        {
            throw new DomainException("Cannot create a bird that is out of bounds.");
		}

        IsAlive = true;
    }

    /// <summary>
    /// Calculates the upwards velocity of the bird after jumping. 
    /// </summary>
    /// <returns>The upwards velocity of the bird.</returns>
    public bool TryJump(out float flyForce)
    {
        if (IsAlive)
        {
            flyForce = FlyForce;
		    return true;
		}

        flyForce = 0;
        return false;
    }

    /// <summary>
    /// Kills the bird if it is not already dead.
    /// </summary>
    /// <returns>True if the bird was alive, false otherwise.</returns>
    public bool TryKill()
    { 
        if (IsAlive)
        {
            IsAlive = false;
            return true;
		}

        return false;
    }

    /// <summary>
    /// Updates the Y position of the bird.
    /// </summary>
    /// <param name="newYPosition">The updated y position.</param>
    /// <returns>Returns whether the bird died because it is out of bounds.</returns>
    public bool UpdateYPosition(float newYPosition)
    {
        YPosition = newYPosition;
        if (IsOutOfBounds())
        {
            return TryKill();
        }

        return false;
    }

    private bool IsOutOfBounds()
    {
        return Math.Abs(YPosition) > Math.Abs(DeathZone);
    }
}

