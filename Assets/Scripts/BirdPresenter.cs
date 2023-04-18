using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPresenter : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float flyForce;
    public float deathZone;

    private BirdEntity birdEntity;

    // Start is called before the first frame update
    void Start()
    {
        birdEntity = new(flyForce, transform.position.y, deathZone);
    }

    // Update is called once per frame
    void Update()
    {
        bool birdFellOutOfBounds = birdEntity.UpdateYPosition(transform.position.y);
        if (birdFellOutOfBounds)
        {
            OnBirdDied();
		}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (birdEntity.TryJump(out float flyForce))
            { 
			    rigidBody.velocity = Vector2.up * flyForce;
		    }
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
    }

}
