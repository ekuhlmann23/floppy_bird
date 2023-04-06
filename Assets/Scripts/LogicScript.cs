using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public const string LogicTag = "Logic";
    private int score = 0;

    public Text scoreText;

    [ContextMenu("Increment Score")]
    public void IncrementScore()
    {
        score++;
        SetScore();
    }

    public void SetScore()
    { 
        scoreText.text = score.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetScore(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
