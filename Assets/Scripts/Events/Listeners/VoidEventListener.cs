using FloppyBird.Events.Channels;
using UnityEngine;
using UnityEngine.Events;

namespace FloppyBird.Events.Listeners
{
    public class VoidEventListener : MonoBehaviour
    {
        public VoidEventChannelSO channel;

        public UnityEvent OnEventRaised;

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

        private void Respond()
        {
            Debug.Log("Triggering event response");
            OnEventRaised?.Invoke();
        }
    }
}
