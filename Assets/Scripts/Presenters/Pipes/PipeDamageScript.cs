using System;
using FloppyBird.Core;
using FloppyBird.Events.Channels;
using FloppyBird.UseCases.Pipes;
using UnityEngine;

namespace FloppyBird.Presenters.Pipes
{
    public class PipeDamageScript : MonoBehaviour
    {
        private IPipeUseCase _pipeUseCase;

        private void Start()
        {
            _pipeUseCase = gameObject.GetComponentInParent<PipePresenter>().pipeUseCase;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == Layers.BirdLayer)
            {
                _pipeUseCase.DamageBird();
            }
        }
    }
}
