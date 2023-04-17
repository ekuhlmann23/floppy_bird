using UnityEngine;
using UnityEngine.Events;

namespace FloppyBird.Events.Channels
{
    [CreateAssetMenu]
    public class IntEventChannelSO : ScriptableObject, IOneParameterEventChannel<int>
    {
        public UnityAction<int> onEventRaised;

        [ContextMenu("Raise Event")]
        public void RaiseEvent(int arg)
        {
            Debug.Log("Event raised on channel");
            onEventRaised?.Invoke(arg);
        }
    }
}
