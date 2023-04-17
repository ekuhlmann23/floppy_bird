using FloppyBird.Events.Channels;
using FloppyBird.Input;
using UnityEngine;
using UnityEngine.Serialization;

namespace FloppyBird.Player
{
    public class BirdScript : MonoBehaviour
    {
        public InputReaderSO inputReader;
        public Rigidbody2D rigidBody;
        public float flyForce;
        [FormerlySerializedAs("deadZone")]
        public float deathZone;
        public VoidEventChannelSO gameOverEventChannel;

        private bool isBirdAlive = true;

        public bool IsBirdAlive => isBirdAlive;

        [ContextMenu("Jump")]
        public void Jump()
        {
            if (isBirdAlive)
            {
                rigidBody.velocity = Vector2.up * flyForce;
            }
        }

        [ContextMenu("Take Damage")]
        public void TakeDamage()
        {
            Debug.Log("Taking damage.");
            if (isBirdAlive)
            {
                Die();
            }
        }

        private void Die()
        {
            isBirdAlive = false;
            Debug.Log("Bird died");
            gameOverEventChannel.RaiseEvent();
        }

        private void Update()
        {
            if (transform.position.y < deathZone && isBirdAlive)
            {
                Die();
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            inputReader.BirdJumped += Jump;
        }

        private void OnDisable()
        {
            inputReader.BirdJumped -= Jump;
        }
    }
}
