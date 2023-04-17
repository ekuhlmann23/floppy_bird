using FloppyBird.Events.Channels;
using UnityEngine;

namespace FloppyBird.Events.Listeners
{
    public class IntEventListener : MonoBehaviour
    {
        public IntEventChannelSO channel;

        public IntEvent OnEventRaised;

        private void OnEnable()
        {
            if (channel != null)
            {
                Debug.Log("Registering event listener.");
                channel.OnEventRaised += Respond;
            }
        }

        private void OnDisable()
        {
            if (channel != null)
            {
                Debug.Log("Unregistering event listener.");
                channel.OnEventRaised -= Respond;
            }
        }

        private void Respond(int arg)
        {
            Debug.Log("Triggering event response");
            OnEventRaised?.Invoke(arg);
        }
    }
}
