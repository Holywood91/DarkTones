using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStartScreen : MonoBehaviour
{
    
    public StartScreen startScreen;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Run TurnOnLight");
        startScreen.StartScreenFunction();
    }
}
