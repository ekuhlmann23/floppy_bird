using FloppyBird.Application.UseCases;
using FloppyBird.Core.Events;
using FloppyBird.Core.EventSystem;
using UnityEngine;
using Zenject;

namespace FloppyBird.Presentation.InterfaceAdapters
{
    public class BirdPresenter : MonoBehaviour
    {
        public float flyForce;
        public float deathZone;

        [Inject]
        private IBirdUseCase _birdUseCase;
        
        [Inject]
        private IEventChannel _eventChannel;

        // Start is called before the first frame update
        void Start()
        {
            _birdUseCase.Initialize(flyForce, transform.position.y, deathZone);

            _eventChannel.Subscribe<BirdDiedEvent>(OnBirdDied);
        }

        private void OnDestroy()
        {
            _eventChannel.Unsubscribe<BirdDiedEvent>(OnBirdDied);
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
            _birdUseCase.HandleBirdCollision();
        }

        private void OnBirdDied()
        { 
            Debug.Log("Bird died");
            Destroy(gameObject);
        }
    }
}
