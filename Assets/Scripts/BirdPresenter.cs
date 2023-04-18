using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPresenter : MonoBehaviour, IBirdMotor
{
    public Rigidbody2D rigidBody;
    public float flyForce;
    public float deathZone;

    private BirdEntity birdEntity;
    private IBirdUseCase birdUseCase;

    // Start is called before the first frame update
    void Start()
    {
        birdEntity = new(flyForce, transform.position.y, deathZone);
        birdUseCase = new BirdUseCase(birdEntity, this);
        birdUseCase.BirdDied += OnBirdDied;
    }

    private void OnDestroy()
    {
        birdUseCase.BirdDied -= OnBirdDied;
    }

    // Update is called once per frame
    void Update()
    {
        birdUseCase.UpdateBirdPosition(transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            birdUseCase.HandleJumpInput();
		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdEntity.TryKill())
        {
            OnBirdDied();
		}
    }

    private void OnBirdDied()
    { 
		Debug.Log("Bird died");
        Destroy(gameObject);
    }

    public void UpdateVerticalVelocity(float upwardVelocity)
    {
        rigidBody.velocity += Vector2.up * upwardVelocity;
    }
}
