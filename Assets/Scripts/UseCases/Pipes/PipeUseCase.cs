using System;
using FloppyBird.Entities;
using FloppyBird.Events.Channels;
using FloppyBird.InterfaceAdapters.GameObjects;

namespace FloppyBird.UseCases.Pipes
{
    public class PipeUseCase : IPipeUseCase
    {
        private const int kPointsAwarded = 1;

        private readonly PipeEntity _pipeEntity;
        private readonly IVoidEventChannel _birdTakeDamageChannel;
        private readonly IDestroyable _destroyable;
        private readonly IOneParameterEventChannel<int> _birdScoresPointsChannel;

        public PipeUseCase(
            PipeEntity pipeEntity,
            IVoidEventChannel birdTakeDamageChannel,
            IDestroyable destroyable,
            IOneParameterEventChannel<int> birdScoresPointsChannel)
        {
            _pipeEntity = pipeEntity;
            _birdTakeDamageChannel = birdTakeDamageChannel;
            _destroyable = destroyable;
            _birdScoresPointsChannel = birdScoresPointsChannel;
        }

        public void DamageBird()
        {
            _birdTakeDamageChannel.RaiseEvent();
        }

        public void MovePipe(float deltaTime)
        {
            if (_pipeEntity.UpdatePosition(deltaTime))
            {
                _destroyable.Destroy();
            }
        }

        public void AwardPointsToBird()
        {
            _birdScoresPointsChannel.RaiseEvent(kPointsAwarded);
        }
    }
}
