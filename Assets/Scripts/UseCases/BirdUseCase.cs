using System;
public class BirdUseCase : IBirdUseCase
{
    private readonly BirdEntity birdEntity;
    private readonly IBirdMotor birdMotor;

    public event Action BirdDied;

    public BirdUseCase(BirdEntity birdEntity, IBirdMotor birdMotor)
    {
        this.birdEntity = birdEntity;
        this.birdMotor = birdMotor;
    }

    public void HandleBirdCollision()
    {
        if (birdEntity.TryKill())
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
        if (birdEntity.TryJump(out float flyForce))
        {
            birdMotor.UpdateVerticalVelocity(flyForce);
	    }
    }

    public void UpdateBirdPosition(float newYPosition)
    {
        bool birdFellOutOfBounds = birdEntity.UpdateYPosition(newYPosition);
        if (birdFellOutOfBounds)
        {
            TriggerBirdDeath();
		}
    }
}

