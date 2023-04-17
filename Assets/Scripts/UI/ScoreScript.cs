using UnityEngine;
using UnityEngine.UI;

namespace FloppyBird.UI
{
    [RequireComponent(typeof(Text))]
    public class ScoreScript : MonoBehaviour
    {
        private Text scoreText;

        private void Start()
        {
            scoreText = GetComponent<Text>();
        }

        public void SetScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
