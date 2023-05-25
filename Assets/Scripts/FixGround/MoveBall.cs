using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    [SerializeField] private GameObject MoveBallTrigger;
    public GameObject microphone;
    private AudioVisualizer audioVisualizer;
    
    public GameObject fixGroundObject;
    private FixGround fixGround;
    
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    private Vector3 pos;
    public Vector3 startPos;

    private int previous;
    private int moveBallCurrent;

    private int collidersHit;

    public int collidersToBeHit;

    public Animator animator;
    public CharacterController2D characterController2D;

    public float PuzzleTimer;

    public GameObject OtherSphere1;
    public GameObject OtherSphere2;
    public GameObject OtherSphere3;
    public GameObject OtherSphere4;
    public GameObject OtherSphere5;

    public GameObject OtherSphere1Blue;
    public GameObject OtherSphere2Blue;
    public GameObject OtherSphere3Blue;
    public GameObject OtherSphere4Blue;
    public GameObject OtherSphere5Blue;

    public GameObject OtherSphere1Pink;
    public GameObject OtherSphere2Pink;
    public GameObject OtherSphere3Pink;
    public GameObject OtherSphere4Pink;
    public GameObject OtherSphere5Pink;

    public ParticleSystem sphere1ParticleSystem;
    public ParticleSystem sphere2ParticleSystem;
    public ParticleSystem sphere3ParticleSystem;
    public ParticleSystem sphere4ParticleSystem;
    public ParticleSystem sphere5ParticleSystem;
    
    public int moveBall1;
    public int moveBall2;
    public int moveBall3;
    public int moveBall4;
    public int moveBall5;
    public int moveBall6;
    public int moveBall7;
    public int moveBall8;


    void Start()
    {
        Debug.developerConsoleVisible = true;
    }
    
    void Awake()
    {
        audioVisualizer = microphone.GetComponent<AudioVisualizer>();
        fixGround = fixGroundObject.GetComponent<FixGround>();
    }
    
    public void MoveBallReset()
    {
        // Reset the Position of the ball to restart the puzzle
        transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
        Debug.Log("RESET THE POSITION");
        collidersHit = 0;
        // Make sure all the colliders and everything is all reset
        
        // Restore the blue sprites
        OtherSphere1Blue.SetActive(true);
        OtherSphere2Blue.SetActive(true);
        OtherSphere3Blue.SetActive(true);
        OtherSphere4Blue.SetActive(true);
        OtherSphere5Blue.SetActive(true);
        // Remove the pink sprites
        OtherSphere1Pink.SetActive(false);
        OtherSphere2Pink.SetActive(false);
        OtherSphere3Pink.SetActive(false);
        OtherSphere4Pink.SetActive(false);
        OtherSphere5Pink.SetActive(false);
        // Restore the box colliders
        OtherSphere1.GetComponent<BoxCollider>().enabled = true;
        OtherSphere2.GetComponent<BoxCollider>().enabled = true;
        OtherSphere3.GetComponent<BoxCollider>().enabled = true;
        OtherSphere4.GetComponent<BoxCollider>().enabled = true;
        OtherSphere5.GetComponent<BoxCollider>().enabled = true;
    }
    
    public void MoveBallFunction()
    {
         // Using Coroutines to be able to run the moveball function and the checkhits function for an exact amount of time
         StartCoroutine(GoSphere());
             

         
         
         
         IEnumerator GoSphere()
         {
             StartCoroutine(StopMovement());
             StartCoroutine(Singing());

             float timePassed = 0;
             transform.position += new Vector3(0 , 0, 0);
             
             while (timePassed < PuzzleTimer)
             {
                 // move ball to the right
                 float speedMod = 1.0f;
                 float deltaTime1 = speedMod * Time.deltaTime;
                 float YVal = 0;
                 float ZVal = 0;
                 transform.position += new Vector3(deltaTime1 , YVal, ZVal);
                 

                if (Time.time > nextActionTime ) {
                    nextActionTime += period;
                    
                    // Here we need to set the height of the ball on the value of the current int
                    // And change the previous int to the value of current
                    moveBallCurrent = audioVisualizer.current;
                    Debug.Log("moveBallCurrent "+ moveBallCurrent);
                    
                    // if the current int does equal 1 and does not equal the previous int do
                    if (moveBallCurrent == 1 && moveBallCurrent != previous)
                    {
                        // Move ball to height of 1
                        // Debug.Log("Move to 1");
                        // Get current position of the sphere and move it only on the y-axis
                        
                        pos = transform.position;
                        transform.position = new Vector3(pos.x, moveBall1, pos.z);
                        previous = 1;
                    }
                    else if (moveBallCurrent == 2 && moveBallCurrent != previous)
                    {
                        // Move ball to height of 2
                        // Debug.Log("Move to 2");
                        // Get current position of the sphere and move it only on the y-axis
                        pos = transform.position;
                        transform.position = new Vector3(pos.x, moveBall2, pos.z);
                        previous = 2;
                    }
                    else if (moveBallCurrent == 3 && moveBallCurrent != previous)
                    {
                        // Move ball to height of 3
                        // Debug.Log("Move to 3");
                        // Get current position of the sphere and move it only on the y-axis
                        pos = transform.position;
                        transform.position = new Vector3(pos.x, moveBall3, pos.z);
                        previous = 3;
                    }
                    else if (moveBallCurrent == 4 && moveBallCurrent != previous)
                    {
                        // Move ball to height of 4
                        // Debug.Log("Move to 4");
                        // Get current position of the sphere and move it only on the y-axis
                        pos = transform.position;
                        transform.position = new Vector3(pos.x, moveBall4, pos.z);
                        previous = 4;
                    }
                    else if (moveBallCurrent == 5 && moveBallCurrent != previous)
                    {
                        // Move ball to height of 5
                        // Debug.Log("Move to 5");
                        // Get current position of the sphere and move it only on the y-axis
                        pos = transform.position;
                        transform.position = new Vector3(pos.x, moveBall5, pos.z);
                        previous = 5;
                    }
                    else if (moveBallCurrent == 6 && moveBallCurrent != previous)
                    {
                        // Move ball to height of 6
                        // Debug.Log("Move to 6");
                        // Get current position of the sphere and move it only on the y-axis
                        pos = transform.position;
                        transform.position = new Vector3(pos.x, moveBall6, pos.z);
                        previous = 6;
                    }
                    else if (moveBallCurrent == 7 && moveBallCurrent != previous)
                    {
                        // Move ball to height of 7
                        // Debug.Log("Move to 7");
                        // Get current position of the sphere and move it only on the y-axis
                        pos = transform.position;
                        transform.position = new Vector3(pos.x, moveBall7, pos.z);
                        previous = 7;
                    }
                    else if (moveBallCurrent == 1000 && moveBallCurrent != previous)
                    {
                        // Move ball to height of 1
                        // Debug.Log("Fucked up");
                        pos = transform.position;
                        transform.position = new Vector3(pos.x, moveBall8, pos.z);
                        previous = 1000;
                    }
                }
                
                timePassed += Time.deltaTime;
                yield return null;
             }
         }
    }
     

     
     // If sphere has collided with 3 other colliders before time runs out then make ground visible
    void OnTriggerEnter(Collider myTigger)
    {
        if (myTigger.gameObject.name == "OtherSphere1" || myTigger.gameObject.name == "OtherSphere2" || myTigger.gameObject.name == "OtherSphere3" || myTigger.gameObject.name == "OtherSphere4" || myTigger.gameObject.name == "OtherSphere5")
        {
            collidersHit++;
            Debug.Log("Hit");

            if (myTigger.gameObject.name == "OtherSphere1")
            {
                // Remove the blue sprite and restore the pink one
                OtherSphere1Blue.SetActive(false);
                OtherSphere1Pink.SetActive(true);
                // Run the particle system
                sphere1ParticleSystem.Play();
                // Remove the box collider to make sure that is cant be hit more than once
                OtherSphere1.GetComponent<BoxCollider>().enabled = false;

            }

            if (myTigger.gameObject.name == "OtherSphere2")
            {
                // Remove the blue sprite and restore the pink one
                OtherSphere2Blue.SetActive(false);
                OtherSphere2Pink.SetActive(true);
                // Run the particle system
                sphere2ParticleSystem.Play();
                // Remove the box collider to make sure that is cant be hit more than once
                OtherSphere2.GetComponent<BoxCollider>().enabled = false;
            }

            if (myTigger.gameObject.name == "OtherSphere3")
            {
                // Remove the blue sprite and restore the pink one
                OtherSphere3Blue.SetActive(false);
                OtherSphere3Pink.SetActive(true);
                // Run the particle system
                sphere3ParticleSystem.Play();
                // Remove the box collider to make sure that is cant be hit more than once
                OtherSphere3.GetComponent<BoxCollider>().enabled = false;
            }

            if (myTigger.gameObject.name == "OtherSphere4")
            {
                // Remove the blue sprite and restore the pink one
                OtherSphere4Blue.SetActive(false);
                OtherSphere4Pink.SetActive(true);
                // Run the particle system
                sphere4ParticleSystem.Play();
                // Remove the box collider to make sure that is cant be hit more than once
                OtherSphere4.GetComponent<BoxCollider>().enabled = false;
            }

            if (myTigger.gameObject.name == "OtherSphere5")
            {
                // Remove the blue sprite and restore the pink one
                OtherSphere5Blue.SetActive(false);
                OtherSphere5Pink.SetActive(true);
                // Run the particle system
                sphere5ParticleSystem.Play();
                // Remove the box collider to make sure that is cant be hit more than once
                OtherSphere5.GetComponent<BoxCollider>().enabled = false;
            }

            if (collidersHit >= collidersToBeHit)
            {
                // Create ground where it needs to be maybe move it in from below
                Debug.Log("Create ground");
                fixGround.fixGroundFunction();
                GameObject.Destroy(MoveBallTrigger);
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
        yield return new WaitForSeconds(PuzzleTimer);
        animator.SetBool("IsSinging", false);
        characterController2D.canMove = true;
        characterController2D.invincible = false;
        yield return new WaitForSeconds(0.4f);
    }
}