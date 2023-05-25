using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixGround : MonoBehaviour
{
    public GameObject ToBeFixedGround;
    public Vector3 FixGroundTarget;
    private float FixGroundSpeed = 0.5F;

    public AudioSource audioSourceGroundRumble;

    public void fixGroundFunction()
    {
        Debug.Log("FIX GROUND NOW");

        // Move the ground towards target position
        StartCoroutine(SmoothFixGround(FixGroundTarget, FixGroundSpeed));
        
    }
    
    IEnumerator SmoothFixGround(Vector3 target, float speed) 
    
    {
        audioSourceGroundRumble.Play();
        while (ToBeFixedGround.transform.position != target)
        {
            ToBeFixedGround.transform.position =
                Vector3.Lerp(ToBeFixedGround.transform.position, target, Time.deltaTime * speed);
            yield return null;
        }
    }   
}
