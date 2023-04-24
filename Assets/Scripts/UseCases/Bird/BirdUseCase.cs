using FloppyBird.Drivers.Physics;
using FloppyBird.Entities;
using FloppyBird.Events.Channels;

namespace FloppyBird.UseCases.Bird
{
    public class BirdUseCase : IBirdUseCase
    {
        private readonly BirdEntity _birdEntity;
        private readonly IVoidEventChannel _gameOverEventChannel;
        private readonly IOneParameterEventChannel<int> _scorePointsEventChannel;
        private readonly IBirdMovementMotor _movementMotor;

        public BirdUseCase(
            BirdEntity birdEntity,
            IVoidEventChannel gameOverEventChannel,
            IOneParameterEventChannel<int> scorePointsEventChannel,
            IBirdMovementMotor movementMotor)
        {
            _birdEntity = birdEntity;
            _gameOverEventChannel = gameOverEventChannel;
            _scorePointsEventChannel = scorePointsEventChannel;
            _movementMotor = movementMotor;
        }

        public void TakeDamage()
        {
            if (_birdEntity.TakeDamage())
            {
                _gameOverEventChannel.RaiseEvent();
            }
        }

        public void ScorePoints(int points)
        {
            if (_birdEntity.CanScorePoint())
            {
                _scorePointsEventChannel.RaiseEvent(points);
            }
        }

        public void FlapWings()
        {
            _movementMotor.UpdateUpwardsVelocity(_birdEntity.FlapWings());
        }

        public void UpdateYPosition(float newYPosition)
        {
            if (_birdEntity.UpdateYPosition(newYPosition))
            {
                TakeDamage();
            }
        }
    }
}
