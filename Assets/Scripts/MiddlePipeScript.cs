using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePipeScript : MonoBehaviour
{
    public GameStateSO gameState;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Layers.BirdLayer)
        {
            if (collision.gameObject.GetComponent<BirdScript>().IsBirdAlive)
            {
                gameState.IncrementScore();
                Debug.Log("Bird scored a point.");
            }
        } 
        
    }
}
