using UnityEngine;
using UnityEngine.Serialization;

namespace FloppyBird
{
    public class MiddlePipeScript : MonoBehaviour
    {
        public const int BirdLayer = 3;
        [FormerlySerializedAs("Logic")] public LogicScript logic;

        // Start is called before the first frame update
        void Start()
        {
            logic = GameObject
                .FindGameObjectWithTag(LogicScript.LogicTag)
                .GetComponent<LogicScript>();
        }

        // Update is called once per frame
        void Update()
        {
        
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
