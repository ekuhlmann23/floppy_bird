using FloppyBird.Core;
using FloppyBird.Events.Channels;
using FloppyBird.Player;
using FloppyBird.Presenters;
using FloppyBird.UseCases.Pipes;
using UnityEngine;

namespace FloppyBird.Pipes
{
    public class MiddlePipeScript : MonoBehaviour
    {
        private IPipeUseCase _pipeUseCase;

        private void Start()
        {
            _pipeUseCase = gameObject.GetComponentInParent<PipePresenter>().pipeUseCase;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == Layers.BirdLayer)
            {
                _pipeUseCase.AwardPointsToBird();
            }

        }
    }
}
