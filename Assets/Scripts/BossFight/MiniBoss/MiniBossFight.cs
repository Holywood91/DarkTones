using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniBossFight : MonoBehaviour
{
 public GameObject microphone;
    [SerializeField] private GameObject TurnOnMiniBossFightTrigger;
    private AudioVisualizer audioVisualizer;

    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public Vector3 pos;

    private int previous;
    private int miniBossFightCurrent;

    public MiniCreateSpellColliders miniCreateSpellColliders;

    // Magic gameobjects
    public GameObject GreenBossCharge;
    public GameObject PinkBossCharge;
    public GameObject YellowBossCharge;
    public GameObject RedBossCharge;
    
    public GameObject GreenBossBolt;
    public GameObject PinkBossBolt;
    public GameObject YellowBossBolt;
    public GameObject RedBossBolt;

    public GameObject GreenCharBolt;
    public GameObject PinkCharBolt;
    public GameObject YellowCharBolt;
    public GameObject RedCharBolt;

    public bool CharShooting;

    public int CharSpellType;
    
    public ParticleSystem SpellParticle;

    public int particleSystemType;

    public float miniBossFightTimePassed = 0;

    void Awake()
    {
        audioVisualizer = microphone.GetComponent<AudioVisualizer>();
        
        //Turn off all the Magic Objects so they are invisible
        GreenBossCharge.SetActive(false);
        PinkBossCharge.SetActive(false);
        YellowBossCharge.SetActive(false);
        RedBossCharge.SetActive(false);
    
        GreenBossBolt.SetActive(false);
        PinkBossBolt.SetActive(false);
        YellowBossBolt.SetActive(false);
        RedBossBolt.SetActive(false);
    }




    public void MiniBossFightFunction()
     {
         Debug.Log("MiniBossFightFunction has started");
         
         // Using Coroutines to be able to run the moveball function and the checkhits function for an exact amount of time
         StartCoroutine(GoFight());

         IEnumerator GoFight()
         {
             // This will wait 1 second like Invoke could do
             yield return new WaitForSeconds(10);
             
             miniBossFightTimePassed = 0;
             while (miniBossFightTimePassed < 20)
             {
                 // Set the position of the sphere to start point, this is needed for when to player has failed previously

                 if (Time.time > nextActionTime ) {
                    nextActionTime += period;
                    
                    // Here we need to set the height of the ball on the value of the current int
                    // And change the previous int to the value of current
                    miniBossFightCurrent = audioVisualizer.current;
                    //Debug.Log("miniBossFightCurrent "+ miniBossFightCurrent);
                    
                    // if the current int does equal 1 and does not equal the previous int do
                    if (miniBossFightCurrent == 1 && miniBossFightCurrent != previous)
                    {
                        // Move ball to height of 1
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, -29, pos.z);
                        previous = 1;
                    }
                    else if (miniBossFightCurrent == 2 && miniBossFightCurrent != previous)
                    {
                        // Move ball to height of 2
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, -28, pos.z);
                        previous = 2;
                    }
                    else if (miniBossFightCurrent == 3 && miniBossFightCurrent != previous)
                    {
                        // Move ball to height of 3
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, -27, pos.z);
                        previous = 3;
                    }
                    else if (miniBossFightCurrent == 4 && miniBossFightCurrent != previous)
                    {
                        // Move ball to height of 4
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, -26, pos.z);
                        previous = 4;
                    }
                    else if (miniBossFightCurrent == 5 && miniBossFightCurrent != previous)
                    {
                        // Move ball to height of 5
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, -25, pos.z);
                        previous = 5;
                    }
                    else if (miniBossFightCurrent == 6 && miniBossFightCurrent != previous)
                    {
                        // Move ball to height of 6
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, -24, pos.z);
                        previous = 6;
                    }
                    else if (miniBossFightCurrent == 7 && miniBossFightCurrent != previous)
                    {
                        // Move ball to height of 7
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, -23, pos.z);
                        previous = 7;
                    }
                    else if (miniBossFightCurrent == 1000 && miniBossFightCurrent != previous)
                    {
                        // Move ball to height of 1
                        pos= transform.position;
                        transform.position = new Vector3(pos.x, -30, pos.z);
                        previous = 1000;
                    }
                 }
                 miniBossFightTimePassed += Time.deltaTime; 
                 
                 yield return null;
             }
         }
     }
     
    
    // floats for the ontriggerstay timers
     float  tSpellA = 0;     
     float  tSpellB = 0;     
     float  tSpellC = 0;     
     float  tSpellD = 0;
     

     private void OnTriggerStay(Collider collider)
     {         
         switch (collider.gameObject.name)
         {
             case "SpellA(Clone)":
                 tSpellA += Time.deltaTime;
                 if(tSpellA > 1.5)
                 {
                     // If Ontriggerstaytime has exceeded 1 seconds
                     Debug.Log("Spell a");
                     CharShooting = true;
                     CharSpellType = 0;
                     particleSystemType = 0;
                     StartCoroutine(playParticleSystems());
                     StartCoroutine(spawnCharBolt());
                     Destroy(GameObject.Find("SpellA(Clone)"));
                 }
                 break;
             case "SpellB(Clone)":
                 tSpellB += Time.deltaTime;
                 if(tSpellB > 1.5) 
                 {
                     // If Ontriggerstaytime has exceeded 1 seconds
                     Debug.Log("Spell b");
                     CharShooting = true;
                     CharSpellType = 1;
                     particleSystemType = 1;
                     StartCoroutine(playParticleSystems());
                     StartCoroutine(spawnCharBolt());
                     Destroy(GameObject.Find("SpellB(Clone)"));
                 }
                 break;
             case "SpellC(Clone)":
                 tSpellC += Time.deltaTime;
                 if(tSpellC > 1.5) 
                 {
                     // If Ontriggerstaytime has exceeded 1 seconds
                     Debug.Log("Spell c");
                     CharShooting = true;
                     CharSpellType = 2;
                     particleSystemType = 2;
                     StartCoroutine(playParticleSystems());
                     StartCoroutine(spawnCharBolt());
                     Destroy(GameObject.Find("SpellC(Clone)"));
                 }
                 break;
             case "SpellD(Clone)":
                 tSpellD += Time.deltaTime;
                 if(tSpellD > 1.5) 
                 {
                     // If Ontriggerstaytime has exceeded 1 seconds
                     Debug.Log("Spell d");
                     CharShooting = true;
                     CharSpellType = 3;
                     particleSystemType = 3;
                     StartCoroutine(playParticleSystems());
                     StartCoroutine(spawnCharBolt());
                     Destroy(GameObject.Find("SpellD(Clone)"));
                 }
                 break;
         }
     }

     IEnumerator playParticleSystems()
     {
         switch (particleSystemType)
         {
             case 0:
                 ParticleSystem spellAParticleSystem = Instantiate(SpellParticle, new Vector3(567, -27, 10), Quaternion.identity);
                 yield return new WaitForSeconds(1);
                 Destroy(GameObject.Find("SpellParticle(Clone)"));
                 break;
             case 1:
                 ParticleSystem spellBParticleSystem = Instantiate(SpellParticle, new Vector3(567, -26, 10), Quaternion.identity);
                 yield return new WaitForSeconds(1);
                 Destroy(GameObject.Find("SpellParticle(Clone)"));
                 break;
             case 2:
                 ParticleSystem spellCParticleSystem = Instantiate(SpellParticle, new Vector3(567, -25, 10), Quaternion.identity);
                 yield return new WaitForSeconds(1);
                 Destroy(GameObject.Find("SpellParticle(Clone)"));
                 break;
             case 3:
                 ParticleSystem spellDParticleSystem = Instantiate(SpellParticle, new Vector3(567, -24, 10), Quaternion.identity);
                 yield return new WaitForSeconds(1);
                 Destroy(GameObject.Find("SpellParticle(Clone)"));
                 break;
         }
     }

     IEnumerator spawnCharBolt()
     {
         switch (CharSpellType)
         {
             case 0:
                 Instantiate(GreenCharBolt, new Vector3(0, 0, 0), Quaternion.identity);
                 break;
             case 1:
                 Instantiate(PinkCharBolt, new Vector3(0, 0, 0), Quaternion.identity);
                 break;
             case 2:
                 Instantiate(YellowCharBolt, new Vector3(0, 0, 0), Quaternion.identity);
                 break;
             case 3:
                 Instantiate(RedCharBolt, new Vector3(0, 0, 0), Quaternion.identity);
                 break;
         }
         yield break;
     }
     

     // reset the floats when ontriggerexit happens
     private void OnTriggerExit(Collider collider)
     {
         tSpellA = 0;     
         tSpellB = 0;     
         tSpellC = 0;     
         tSpellD = 0;
     }
}
