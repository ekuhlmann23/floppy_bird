using FloppyBird.Drivers.Input;
using FloppyBird.Drivers.Physics;
using FloppyBird.Entities;
using FloppyBird.Events.Channels;
using FloppyBird.InterfaceAdapters.Input;
using FloppyBird.UseCases.Bird;
using UnityEngine;
using UnityEngine.Serialization;

namespace FloppyBird.Presenters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdPresenter : MonoBehaviour, IBirdMovementMotor
    {
        public InputReaderSO inputReader;
        public float flyForce;
        [FormerlySerializedAs("deadZone")]
        public float deathZone;
        public VoidEventChannelSO gameOverEventChannel;
        public IntEventChannelSO scorepointsEventChannel;

        private BirdEntity _birdEntity;
        private IInputReader _inputReader;
        private IBirdUseCase _birdUseCase;
        private Rigidbody2D _rigidBody;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _birdEntity = new BirdEntity(transform.position.y, flyForce, deathZone);
            _birdUseCase = new BirdUseCase(
                _birdEntity,
                gameOverEventChannel,
                scorepointsEventChannel,
                movementMotor: this);
            _inputReader = inputReader;
        }

        [ContextMenu("Jump")]
        public void Jump()
        {
            _birdUseCase.FlapWings();
        }

        [ContextMenu("Take Damage")]
        public void TakeDamage()
        {
            Debug.Log("Taking damage.");
            _birdUseCase.TakeDamage();
        }

        private void Update()
        {
            _birdUseCase.UpdateYPosition(transform.position.y);
        }

        private void OnEnable()
        {
            inputReader.BirdJumped += Jump;
        }

        private void OnDisable()
        {
            inputReader.BirdJumped -= Jump;
        }

        public void UpdateUpwardsVelocity(float newVelocity)
        {
            _rigidBody.velocity = Vector2.up * newVelocity;
        }

        public void ScorePoints(int points)
        {
            _birdUseCase.ScorePoints(points);
        }
    }
}
