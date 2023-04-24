using FloppyBird.Application.UseCases;
using UnityEngine;

namespace FloppyBird.Presentation.Presenters
{
    public class BirdPresenter : MonoBehaviour
    {
        public Rigidbody2D rigidBody;
        public float flyForce;
        public float deathZone;

        private IBirdUseCase _birdUseCase;

        // Start is called before the first frame update
        void Start()
        {
            _birdUseCase = new BirdUseCase();
            _birdUseCase.Initialize(flyForce, transform.position.y, deathZone);
        }

        // Update is called once per frame
        void Update()
        {
            bool birdFellOutOfBounds = _birdUseCase.UpdateBirdPosition(transform.position.y);
            if (birdFellOutOfBounds)
            {
                OnBirdDied();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_birdUseCase.TryBirdJump(out float flyForce))
                { 
                    rigidBody.velocity = Vector2.up * flyForce;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_birdUseCase.BirdCollide())
            {
                OnBirdDied();
            }
        }

        private void OnBirdDied()
        { 
            Debug.Log("Bird died");
        }

    }
}
