using UnityEngine;
using UnityEngine.UI;

namespace FloppyBird.UI
{
    [RequireComponent(typeof(Text))]
    public class ScoreScript : MonoBehaviour
    {
        private Text _scoreText;

        private void Start()
        {
            _scoreText = GetComponent<Text>();
        }

        public void SetScore(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}
