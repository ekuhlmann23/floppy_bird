using FloppyBird.Core;
using FloppyBird.Events.Channels;
using FloppyBird.Player;
using UnityEngine;

namespace FloppyBird.Pipes
{
    public class MiddlePipeScript : MonoBehaviour
    {
        public IntEventChannelSO playerScored;

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == Layers.BirdLayer)
            {
                if (collision.gameObject.GetComponent<BirdScript>().IsBirdAlive)
                {
                    Debug.Log("Bird scored a point.");

                }
            } 
        
        }
    }
}
