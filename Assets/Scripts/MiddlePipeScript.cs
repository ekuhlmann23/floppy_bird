using UnityEngine;
using UnityEngine.Serialization;

namespace FloppyBird
{
    public class MiddlePipeScript : MonoBehaviour
    {
        public const int BirdLayer = 3;
        [FormerlySerializedAs("Logic")] public LogicScript logic;

        // Start is called before the first frame update
        private void Start()
        {
            logic = GameObject
                .FindGameObjectWithTag(LogicScript.LogicTag)
                .GetComponent<LogicScript>();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == BirdLayer)
            {
                logic.IncrementScore();
                Debug.Log("Bird scored a point.");
            } 
        
        }
    }
}
