using FloppyBird.Entities;
using FloppyBird.InterfaceAdapters.Physics;
using FloppyBird.UseCases;
using UnityEngine;

namespace FloppyBird
{
    public class BirdPresenter : MonoBehaviour, IBirdMotor
    {
        public Rigidbody2D rigidBody;
        public float flyForce;
        public float deathZone;

        private BirdEntity _birdEntity;
        private IBirdUseCase _birdUseCase;

        // Start is called before the first frame update
        void Start()
        {
            _birdEntity = new(flyForce, transform.position.y, deathZone);
            _birdUseCase = new BirdUseCase(_birdEntity, this);
            _birdUseCase.BirdDied += OnBirdDied;
        }

        private void OnDestroy()
        {
            _birdUseCase.BirdDied -= OnBirdDied;
        }

        // Update is called once per frame
        void Update()
        {
            _birdUseCase.UpdateBirdPosition(transform.position.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _birdUseCase.HandleJumpInput();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_birdEntity.TryKill())
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
            rigidBody.velocity = Vector2.up * upwardVelocity;
        }
    }
}
