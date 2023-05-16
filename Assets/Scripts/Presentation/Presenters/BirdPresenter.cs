using System.Linq;
using FloppyBird.Application.UseCases;
using FloppyBird.Domain.Drivers;
using FloppyBird.Domain.Entities;
using FloppyBird.Domain.Events;
using FloppyBird.Domain.EventSystem;
using FloppyBird.Presentation.InterfaceAdapters;
using FloppyBird.Presentation.InterfaceAdapters.Input;
using UnityEngine;
using Zenject;

namespace FloppyBird.Presentation.Presenters
{
    
    [RequireComponent(typeof(BirdMovement))]
    public class BirdPresenter : MonoBehaviour
    {
        public float flyForce;
        public float deathZone;
        public InputReaderSO inputReader;

        private BirdMovement _birdMovement;

        [Inject]
        private IBirdUseCase _birdUseCase;

        [Inject]
        private IEventChannel _eventChannel;

        [Inject]
        private IDateTimeProvider _dateTimeProvider;

        [Inject]
        private IPlayerScoresUseCase _playerScoresUseCase;

        // Start is called before the first frame update
        void Start()
        {
            _eventChannel.Subscribe<BirdDiedEvent>(OnBirdDied);
            inputReader.BirdJump += OnBirdJump;
            _birdMovement = GetComponent<BirdMovement>();
            _birdUseCase.Initialize(_birdMovement, flyForce, transform.position.y, deathZone);
        }

        private void OnBirdJump()
        {
            _birdUseCase.BirdJump();
        }

        private void OnDestroy()
        {
            inputReader.BirdJump -= OnBirdJump;
            _eventChannel.Unsubscribe<BirdDiedEvent>(OnBirdDied);
        }

        // Update is called once per frame
        void Update()
        {
            _birdUseCase.UpdateBirdPosition(transform.position.y);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _birdUseCase.BirdCollide();
        }

        private async void OnBirdDied(BirdDiedEvent birdDiedEvent)
        { 
            Debug.Log($"Bird died at {_dateTimeProvider.GetCurrentTime()}");
            var player = await _playerScoresUseCase.LoadPlayerWithScoresAsync("ABC");

            Debug.Log(player.HighScores.FirstOrDefault()?.Score);
            Destroy(gameObject);
        }

    }
}
