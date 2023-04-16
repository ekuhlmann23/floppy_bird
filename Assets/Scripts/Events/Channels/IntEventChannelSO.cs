using UnityEngine;
using UnityEngine.Events;

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
