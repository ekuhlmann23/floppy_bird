using FloppyBird.Events.Channels;
using UnityEngine;

namespace FloppyBird.State
{
    [CreateAssetMenu]
    public class GameStateSO : ScriptableObject, IGameState
    {
        public IntEventChannelSO playerScoredChannel;
        public VoidEventChannelSO gameRestartChannel;

        public int Score { get; private set; }

        [ContextMenu("Increment Score")]
        public void IncrementScore()
        {
            SetScore(Score + 1);
        }

        private void Init()
        {
            SetScore(0);
        }

        private void SetScore(int newScore)
        {
            Score = newScore;
        }

        private void OnEnable()
        {
            Init();
            gameRestartChannel.onEventRaised += Init;
            playerScoredChannel.onEventRaised += SetScore;
        }

        private void OnDisable()
        {
            gameRestartChannel.onEventRaised -= Init;
            playerScoredChannel.onEventRaised -= SetScore;
        }
    }
}
