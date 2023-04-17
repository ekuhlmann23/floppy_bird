using FloppyBird.Events.Channels;
using UnityEngine;

namespace FloppyBird.UI
{
    public class GameOverScript : MonoBehaviour
    {
        public VoidEventChannelSO restartGameEventChannel;
        public GameObject gameOverScreenUI;

        public void GameOver()
        {
            Debug.Log("Game over screen.");
            gameOverScreenUI.SetActive(true);
        }

        public void RestartGame()
        {
            Debug.Log("Restarting game.");
            gameObject.SetActive(false);
            restartGameEventChannel.RaiseEvent();
        }
    }
}
