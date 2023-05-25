using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLight : MonoBehaviour
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

    public GameObject ChandelierOff;
    public GameObject ChandelierTurnOn;
    public GameObject TurnOnLightChandelier;

    public SpriteRenderer OtherSphereBlue;
    public ParticleSystem OtherSphereParticle;
    
    public Animator animator;
    public CharacterController2D characterController2D;

    bool TurnonLightStarted = false;

    public int turnOnLight1;
    public int turnOnLight2;
    public int turnOnLight3;
    public int turnOnLight4;
    public int turnOnLight5;
    public int turnOnLight6;
    public int turnOnLight7;
    public int turnOnLight8;

    void Awake()
    {
        audioVisualizer = microphone.GetComponent<AudioVisualizer>();
        
        ChandelierTurnOn.SetActive(false);
        TurnOnLightChandelier.SetActive(false);
    }

    // Update is called once per frame
     public void TurnOnLightFunction()
     {
         // Using Coroutines to be able to run the moveball function and the checkhits function for an exact amount of time
         StartCoroutine(GoLight());
         
         IEnumerator GoLight()
         {
             // This will wait 1 second like Invoke could do, remove this if you don't need it
             StartCoroutine(StopMovement());
             StartCoroutine(Singing());

             float timePassed = 0;
             while (timePassed < 5)
             {
                 // Set the position of the sphere to start point, this is needed for when to player has failed previously

                 if (Time.time > nextActionTime ) {
                    nextActionTime += period;
                    
                    // Here we need to set the height of the ball on the value of the current int
                    // And change the previous int to the value of current
                    turnOnLightCurrent = audioVisualizer.current;
                    Debug.Log("turnOnLightCurrent "+ turnOnLightCurrent);
                    
                    // if the current int does equal 1 and does not equal the previous int do
                    if (turnOnLightCurrent == 1 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 1
                        // Debug.Log("Move to 1");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, turnOnLight1, pos.z);
                        previous = 1;
                        
                    }
                    else if (turnOnLightCurrent == 2 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 2
                        // Debug.Log("Move to 2");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, turnOnLight2, pos.z);
                        previous = 2;
                    }
                    else if (turnOnLightCurrent == 3 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 3
                        // Debug.Log("Move to 3");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, turnOnLight3, pos.z);
                        previous = 3;
                    }
                    else if (turnOnLightCurrent == 4 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 4
                        // Debug.Log("Move to 4");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, turnOnLight4, pos.z);
                        previous = 4;
                    }
                    else if (turnOnLightCurrent == 5 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 5
                        // Debug.Log("Move to 5");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, turnOnLight5, pos.z);
                        previous = 5;
                    }
                    else if (turnOnLightCurrent == 6 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 6
                        // Debug.Log("Move to 6");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, turnOnLight6, pos.z);
                        previous = 6;
                    }
                    else if (turnOnLightCurrent == 7 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 7
                        // Debug.Log("Move to 7");
                        // Get current position of the sphere and move it only on the y-axis
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, turnOnLight7, pos.z);
                        previous = 7;
                    }
                    else if (turnOnLightCurrent == 1000 && turnOnLightCurrent != previous)
                    {
                        // Move ball to height of 1
                        // Debug.Log("Fucked up");
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, turnOnLight8, pos.z);
                        previous = 1000;
                    }
                 }
                 timePassed += Time.deltaTime; 
                 
                 
                 yield return null;
             }
         }
     }
     float  t = 0;
                 
     void OnTriggerEnter(Collider other) 
     {
         t = 0;
     }
     void OnTriggerStay(Collider other)
     {
         t += Time.deltaTime;
         if(t > 3 && TurnonLightStarted == false) {
             // Turn on the light
             Debug.Log("TurnOnLight");
             GameObject.Destroy(TurnOnLightTrigger);
             StartCoroutine(LightFixes());
             TurnonLightStarted = true;
             
             // Remove the blue sprites
             OtherSphereBlue.enabled = false;
             // Run the particle system
             OtherSphereParticle.Play();

             StartCoroutine(StopSinging());
         }
     }
     
     IEnumerator LightFixes()
     
         {
             // Turn off ChandelierOff
             ChandelierOff.SetActive(false);
             // Turn on ChandelierTurnOn
             ChandelierTurnOn.SetActive(true);
             // Wait for time to let the animation play
             yield return new WaitForSeconds(1);
             // Turn off ChandelierTurnOn
             ChandelierTurnOn.SetActive(false);
             // Turn on TurnOnLightChandelier
             TurnOnLightChandelier.SetActive(true);
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
         yield return new WaitForSeconds(5f);
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
     
}

