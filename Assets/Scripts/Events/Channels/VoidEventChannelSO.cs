using UnityEngine;
using UnityEngine.Events;

namespace FloppyBird.Events.Channels
{
    [CreateAssetMenu]
    public class VoidEventChannelSO : ScriptableObject, IVoidEventChannel
    {
        public UnityAction onEventRaised;

        [ContextMenu("Raise Event")]
        public void RaiseEvent()
        {
            Debug.Log("Event raised on channel");
            onEventRaised?.Invoke();
        }
    }
}
