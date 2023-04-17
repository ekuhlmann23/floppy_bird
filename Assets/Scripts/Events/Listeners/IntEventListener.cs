using System;
using FloppyBird.Events.Channels;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace FloppyBird.Events.Listeners
{
    [Serializable]
    public class IntEvent : UnityEvent<int>
    {
    }

    public class IntEventListener : MonoBehaviour
    {
        public IntEventChannelSO channel;

        [FormerlySerializedAs("OnEventRaised")]
        public IntEvent onEventRaised;

        private void OnEnable()
        {
            if (channel != null)
            {
                Debug.Log("Registering event listener.");
                channel.onEventRaised += Respond;
            }
        }

        private void OnDisable()
        {
            if (channel != null)
            {
                Debug.Log("Unregistering event listener.");
                channel.onEventRaised -= Respond;
            }
        }

        private void Respond(int arg)
        {
            Debug.Log("Triggering event response");
            onEventRaised?.Invoke(arg);
        }
    }
}
