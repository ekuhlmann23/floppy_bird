using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float flyForce;


    private bool isBirdAlive = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isBirdAlive)
        {
            rigidBody.velocity = Vector2.up * flyForce;
		}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBirdAlive)
        { 
			isBirdAlive = false;
			Debug.Log("Bird died");
		}
    }

}
