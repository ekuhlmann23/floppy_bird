using UnityEngine;

public class PipeDamageScript : MonoBehaviour
{
    public VoidEventChannelSO playerTakesDamageEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Layers.BirdLayer)
        {
            playerTakesDamageEvent.RaiseEvent();
        }
    }
}
