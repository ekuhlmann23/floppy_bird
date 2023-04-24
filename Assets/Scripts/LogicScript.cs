using UnityEngine;
using UnityEngine.UI;

namespace FloppyBird
{
    public class LogicScript : MonoBehaviour
    {
        public const string LogicTag = "Logic";
        private int _score = 0;

        public Text scoreText;

        [ContextMenu("Increment Score")]
        public void IncrementScore()
        {
            _score++;
            SetScore();
        }

        public void SetScore()
        { 
            scoreText.text = _score.ToString();
        }

        // Start is called before the first frame update
        private void Start()
        {
            SetScore(); 
        }
    }
}
