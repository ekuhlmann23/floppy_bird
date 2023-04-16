using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction OnEventRaised;

    [ContextMenu("Raise Event")]
    public void RaiseEvent()
    {
        Debug.Log("Event raised on channel");
        OnEventRaised?.Invoke();
    }
}
