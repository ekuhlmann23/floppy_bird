using UnityEngine;

namespace FloppyBird.Pipes
{
    public class PipeMovementScript : MonoBehaviour
    {
        public float movementSpeed;
        public float deathZone = -50;

        // Update is called once per frame
        void Update()
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime; 
            if (transform.position.x < deathZone)
            {
                Destroy(gameObject);
            }
        }
    }
}
