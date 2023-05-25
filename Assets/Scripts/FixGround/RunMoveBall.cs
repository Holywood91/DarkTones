using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunMoveBall : MonoBehaviour
{
    public GameObject moveBallObject;
    private MoveBall moveBall;
    
    void Awake()
    {
        moveBall = moveBallObject.GetComponent<MoveBall>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Run MoveBall");
        moveBall.MoveBallReset();
        moveBall.MoveBallFunction();
    }
}
