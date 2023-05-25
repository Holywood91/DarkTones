using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayQuit : MonoBehaviour
{
    public GameObject playQuitObject;
    private PlayQuit playQuit;
    
    void Awake()
    {
        playQuit = playQuitObject.GetComponent<PlayQuit>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Run PlayQuit");
        playQuit.PlayQuitFunction();
    }
}
