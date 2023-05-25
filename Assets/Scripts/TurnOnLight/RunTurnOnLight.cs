using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTurnOnLight : MonoBehaviour
{
    public GameObject turnOnLightObject;
    private TurnOnLight turnOnLight;
    
    void Awake()
    {
        turnOnLight = turnOnLightObject.GetComponent<TurnOnLight>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Run TurnOnLight");
        turnOnLight.TurnOnLightFunction();
    }
}
