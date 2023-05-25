using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayQuit : MonoBehaviour
{
    public GameObject microphone;
    [SerializeField] private GameObject TurnOnLightTrigger;
    private AudioVisualizer audioVisualizer;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Vector3 pos;

    private int previous;
    private int turnOnLightCurrent;

    private int collidersHit;

    public Animator animator;
    public CharacterController2D characterController2D;

    bool TurnonLightStarted = false;

    public int playQuit1;
    public int playQuit2;
    public int playQuit3;
    public int playQuit4;
    public int playQuit5;
    public int playQuit6;
    public int playQuit7;
    public int playQuit8;

    public int playQuitint;
    
    public Animator fadeAnimator;

    void Awake()
    {
        audioVisualizer = microphone.GetComponent<AudioVisualizer>();
    }

    // Update is called once per frame
     public void PlayQuitFunction()
     {
         // Using Coroutines to be able to run the moveball function and the checkhits function for an exact amount of time
         StartCoroutine(GoLight());
         
         IEnumerator GoLight()
         {
             // This will wait 1 second like Invoke could do, remove this if you don't need it
             StartCoroutine(StopMovement());
             StartCoroutine(Singing());

             float timePassed = 0;
             while (timePassed < 10)
             {
                 // Set the position of the sphere to start point, this is needed for when to player has failed previously

                 if (Time.time > nextActionTime ) {
                    nextActionTime += period;
                    
                    // Here we need to set the height of the ball on the value of the current int
                    // And change the previous int to the value of current
                    turnOnLightCurrent = audioVisualizer.current;
                    //Debug.Log("turnOnLightCurrent "+ turnOnLightCurrent);
                    
                    // if the current int does equal 1 and does not equal the previous int do
                    if (turnOnLightCurrent == 1 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 1
                        // Debug.Log("Move to 1");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, playQuit1, pos.z);
                        previous = 1;
                        
                    }
                    else if (turnOnLightCurrent == 2 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 2
                        // Debug.Log("Move to 2");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, playQuit2, pos.z);
                        previous = 2;
                    }
                    else if (turnOnLightCurrent == 3 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 3
                        // Debug.Log("Move to 3");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, playQuit3, pos.z);
                        previous = 3;
                    }
                    else if (turnOnLightCurrent == 4 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 4
                        // Debug.Log("Move to 4");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, playQuit4, pos.z);
                        previous = 4;
                    }
                    else if (turnOnLightCurrent == 5 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 5
                        // Debug.Log("Move to 5");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, playQuit5, pos.z);
                        previous = 5;
                    }
                    else if (turnOnLightCurrent == 6 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 6
                        // Debug.Log("Move to 6");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, playQuit6, pos.z);
                        previous = 6;
                    }
                    else if (turnOnLightCurrent == 7 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 7
                        // Debug.Log("Move to 7");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, playQuit7, pos.z);
                        previous = 7;
                    }
                    else if (turnOnLightCurrent == 1000 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 1
                        // Debug.Log("Fucked up");
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, playQuit8, pos.z);
                        previous = 1000;
                    }
                 }
                 timePassed += Time.deltaTime;
                 yield return null;
             }
         }
     }

     float  tSpellA = 0;     
     float  tSpellB = 0;
     

     private void OnTriggerStay(Collider collider)
     {         
         switch (collider.gameObject.name)
         {
             case "Play":
                 tSpellA += Time.deltaTime;
                 if(tSpellA > 2)
                 {
                     playQuitint = 0;
                     StartCoroutine(PlayQuitCoroutine());
                 }
                 break;
             case "Quit":
                 tSpellB += Time.deltaTime;
                 if(tSpellB > 2) 
                 {
                     playQuitint = 1;
                     StartCoroutine(PlayQuitCoroutine());
                     Debug.Log("Quit");
                 }
                 break;
         }
     }


     private void OnTriggerExit(Collider collider)
     {
         tSpellA = 0;     
         tSpellB = 0;
     }

     IEnumerator PlayQuitCoroutine()
     {
         switch (playQuitint)
         {
             case 0:
                 StartCoroutine(GoToIntroScene());
                 break;
             case 1:
                 Application.Quit();
                 break;
         }
         yield break;
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
         yield return new WaitForSeconds(10f);
         animator.SetBool("IsSinging", false);
         characterController2D.canMove = true;
         characterController2D.invincible = false;
         yield return new WaitForSeconds(0.4f);
     }
     
     IEnumerator StopSinging()
     {
         animator.SetBool("IsSinging", false);
         characterController2D.canMove = true;
         characterController2D.invincible = false;
         yield return new WaitForSeconds(0.4f);
     }
     
     IEnumerator GoToIntroScene()
     {
         fadeAnimator.SetTrigger("FadeOutTrigger");
         yield return new WaitForSeconds(1);
         SceneManager.LoadScene("Intro");
     }
     
}

