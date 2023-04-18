using System;
public interface IBirdUseCase
{
    public void UpdateBirdPosition(float newYPosition);
    public void HandleJumpInput();
    public void HandleBirdCollision();

    public event Action BirdDied;
}

