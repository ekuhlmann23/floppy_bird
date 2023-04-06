using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePipeScript : MonoBehaviour
{
    public const int BirdLayer = 3;
    public LogicScript Logic;

    // Start is called before the first frame update
    void Start()
    {
        Logic = GameObject
		    .FindGameObjectWithTag(LogicScript.LogicTag)
		    .GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == BirdLayer)
        {
            Logic.IncrementScore();
            Debug.Log("Bird scored a point.");
        } 
        
    }
}
