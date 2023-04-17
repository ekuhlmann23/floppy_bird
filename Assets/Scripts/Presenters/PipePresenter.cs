using System;
using FloppyBird.Entities;
using FloppyBird.Events.Channels;
using FloppyBird.InterfaceAdapters.GameObjects;
using FloppyBird.UseCases.Pipes;
using UnityEngine;

namespace FloppyBird.Presenters
{
    public class PipePresenter : MonoBehaviour, IDestroyable
    {
        public float movementSpeed;
        public float deathZone = -50;

        public VoidEventChannelSO birdTakeDamageChannel;
        public IntEventChannelSO birdScoredPointsChannel;

        public IPipeUseCase pipeUseCase;
        private PipeEntity _pipeEntity;

        private void Start()
        {
            var position = transform.position;
            _pipeEntity = new PipeEntity(position.x, position.y, movementSpeed, deathZone);
            pipeUseCase = new PipeUseCase(_pipeEntity, birdTakeDamageChannel, this, birdScoredPointsChannel);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
