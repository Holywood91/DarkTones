using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen: MonoBehaviour
{
    public GameObject microphone;
    [SerializeField] private GameObject TurnOnLightTrigger;
    private AudioVisualizer audioVisualizer;

    public GameObject toolTip;
    
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Vector3 pos;

    private int previous;
    private int startScreenCurrent;
    
    public Animator animator;
    public CharacterController2D characterController2D;

    bool TurnonLightStarted = false;

    void Awake()
    {
        audioVisualizer = microphone.GetComponent<AudioVisualizer>();
        toolTip.SetActive(false);
    }

    // Update is called once per frame
     public void StartScreenFunction()
     {
         // Using Coroutines to be able to run the moveball function and the checkhits function for an exact amount of time
         StartCoroutine(GoStartScreen());
         
         IEnumerator GoStartScreen()
         {
             // This will wait 1 second like Invoke could do, remove this if you don't need it
             StartCoroutine(StopMovement());
             StartCoroutine(Singing());

             StartCoroutine(ShowToolTip());

             float timePassed = 0;
             while (timePassed < 15)
             {
                 // Set the position of the sphere to start point, this is needed for when to player has failed previously

                 if (Time.time > nextActionTime ) {
                    nextActionTime += period;
                    
                    // Here we need to set the height of the ball on the value of the current int
                    // And change the previous int to the value of current
                    startScreenCurrent = audioVisualizer.current;
                    Debug.Log("startScreenCurrent "+ startScreenCurrent);
                    
                    // if the current int does equal 1 and does not equal the previous int do
                    if (startScreenCurrent == 1 && startScreenCurrent != previous)
                    {
                        // Move ball to height of 1
                        // Debug.Log("Move to 1");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, 0, pos.z);
                        previous = 1;
                        
                    }
                    else if (startScreenCurrent == 2 && startScreenCurrent != previous)
                    {
                        // Move ball to height of 2
                        // Debug.Log("Move to 2");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, 1, pos.z);
                        previous = 2;
                    }
                    else if (startScreenCurrent == 3 && startScreenCurrent != previous)
                    {
                        // Move ball to height of 3
                        // Debug.Log("Move to 3");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, 2, pos.z);
                        previous = 3;
                    }
                    else if (startScreenCurrent == 4 && startScreenCurrent != previous)
                    {
                        // Move ball to height of 4
                        // Debug.Log("Move to 4");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, 3, pos.z);
                        previous = 4;
                    }
                    else if (startScreenCurrent == 5 && startScreenCurrent != previous)
                    {
                        // Move ball to height of 5
                        // Debug.Log("Move to 5");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, 4, pos.z);
                        previous = 5;
                    }
                    else if (startScreenCurrent == 6 && startScreenCurrent != previous)
                    {
                        // Move ball to height of 6
                        // Debug.Log("Move to 6");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, 5, pos.z);
                        previous = 6;
                    }
                    else if (startScreenCurrent == 7 && startScreenCurrent != previous)
                    {
                        // Move ball to height of 7
                        // Debug.Log("Move to 7");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, 6, pos.z);
                        previous = 7;
                    }
                    else if (startScreenCurrent == 1000 && startScreenCurrent != previous)
                    {
                        // Move ball to height of 1
                        // Debug.Log("Fucked up");
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, -1, pos.z);
                        previous = 1000;
                    }
                 }
                 timePassed += Time.deltaTime; 
                 
                 //toolTip.SetActive(false);
                 
                 yield return null;
             }
         }
     }

     IEnumerator StopMovement()
     {
         animator.SetBool("IsSinging", false);
         characterController2D.canMove = false;
         characterController2D.invincible = true;
         yield return new WaitForSeconds(0.1f);
         characterController2D.m_Rigidbody2D.velocity = new Vector2(0, characterController2D.m_Rigidbody2D.velocity.y);
         yield return new WaitForSeconds(0.1f);
     }
    
     IEnumerator Singing()
     {
         animator.SetBool("IsSinging", true);
         yield return new WaitForSeconds(15f);
         animator.SetBool("IsSinging", false);
         characterController2D.canMove = true;
         characterController2D.invincible = false;
         yield return new WaitForSeconds(0.4f);
     }

     IEnumerator ShowToolTip()
     {
         toolTip.SetActive(true);
         yield return new WaitForSeconds(15f);
         toolTip.SetActive(false);
     }
}

