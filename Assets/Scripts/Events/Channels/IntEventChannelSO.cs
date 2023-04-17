using UnityEngine;
using UnityEngine.Events;

namespace FloppyBird.Events.Channels
{
    [CreateAssetMenu]
    public class IntEventChannelSO : ScriptableObject
    {
        public UnityAction<int> OnEventRaised;

        [ContextMenu("Raise Event")]
        public void RaiseEvent(int arg)
        {
            Debug.Log("Event raised on channel");
            OnEventRaised?.Invoke(arg);
        }
    }
}
