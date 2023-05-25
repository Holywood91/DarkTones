using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MiniCreateSpellColliders : MonoBehaviour
{
    public int spellType;

    public Animator animator;
    public CharacterController2D characterController2D;
    
    // Spell gameobjects
    public GameObject SpellA;
    public GameObject SpellB;
    public GameObject SpellC;
    public GameObject SpellD;
    
    // Magic gameobjects
    public GameObject GreenBossCharge;
    public GameObject PinkBossCharge;
    public GameObject YellowBossCharge;
    public GameObject RedBossCharge;
    
    public GameObject GreenBossBolt;
    public GameObject PinkBossBolt;
    public GameObject YellowBossBolt;
    public GameObject RedBossBolt;

    public MiniBossFight miniBossFight;

    private int randomisedSpellType;
    private int previousSpellType;
    
    public GameObject introText;

    public int RandomiseDeathText;

    public GameObject CharDeathText1;
    public GameObject CharDeathText2;
    public GameObject CharDeathText3;


    private void Awake()
    {
        introText.SetActive(false);
        CharDeathText1.SetActive(false);
        CharDeathText2.SetActive(false);
        CharDeathText3.SetActive(false);
    }

    public void CreateSpellColliderTypes()
    {
         // Using Coroutines to be able to run the function for an exact amount of time
         StartCoroutine(GoCreate());
         
         IEnumerator GoCreate()
         {
             // Stop char movement
             StartCoroutine(StopMovement());
             
             // Wait to start puzzle
             StartCoroutine(introTextRoutine());
             yield return new WaitForSeconds(10);
             
             // Start Singing animation
             StartCoroutine(Singing());




             // Create spellcolliders every 5 seconds under 20 seconds
             
             float timePassed = 0;
             while (timePassed < 20)
             {

                 // Run randomiser
                 RandomiseSpellsFunction();
                 
                 // Run the function that creates a spellcollider on the basis of the spelltype int
                 CreateASpellColliderFunction();
                 
                 
                 // Wait for 5 seconds
                 yield return new WaitForSeconds(5);
                 
                 // Make the Boss Shoot
                 if (miniBossFight.CharShooting == false)
                 {
                     StartCoroutine(BossSpells());
                 }

                 miniBossFight.CharShooting = false;
                 
                 
                 // Run the destroy for the spellcollider
                 DestroySpellCollider();
                 // Run randomiser
                 RandomiseSpellsFunction();
                 // Run the function that creates a spellcollider on the basis of the spelltype int
                 CreateASpellColliderFunction();
                 // Wait for 5 seconds
                 yield return new WaitForSeconds(5);
                 // Make the Boss Shoot

                 if (miniBossFight.CharShooting == false)
                 {
                     StartCoroutine(BossSpells());
                 }

                 miniBossFight.CharShooting = false;


                 // Run the destroy for the spellcollider
                 DestroySpellCollider();
                 // Run randomiser
                 RandomiseSpellsFunction();
                 // Run the function that creates a spellcollider on the basis of the spelltype int
                 CreateASpellColliderFunction();
                 // Wait for 5 seconds
                 yield return new WaitForSeconds(5);
                 // Make the Boss Shoot

                 if (miniBossFight.CharShooting == false)
                 {
                     StartCoroutine(BossSpells());
                 }

                 miniBossFight.CharShooting = false;




                 // Run the destroy for the spellcollider
                 DestroySpellCollider();
                 // Run randomiser
                 RandomiseSpellsFunction();
                 // Run the function that creates a spellcollider on the basis of the spelltype int
                 CreateASpellColliderFunction();
                 // Wait for 5 seconds
                 yield return new WaitForSeconds(5);
                 // Make the Boss Shoot

                 if (miniBossFight.CharShooting == false)
                 {
                     StartCoroutine(BossSpells());
                 }

                 miniBossFight.CharShooting = false;


                 // Run the destroy for the spellcollider
                 DestroySpellCollider();
                 
                 timePassed += Time.deltaTime;
                 
                 StartCoroutine(StopSinging());
                 
                 yield return null;
                 break;
             }
         }
    }

    public void RandomiseSpellsFunction()
    {
        randomisedSpellType = Random.Range(0, 4);

        if (randomisedSpellType != previousSpellType)
        {
            spellType = randomisedSpellType;
            previousSpellType = spellType;
        } 
        else if (randomisedSpellType == 0)
        {
            spellType = 1;
            previousSpellType = spellType;
        }
        else if (randomisedSpellType == 1)
        {
            spellType = 2;
            previousSpellType = spellType;
        }
        else if (randomisedSpellType == 3)
        {
            spellType = 0;
            previousSpellType = spellType;
        }

    }
    
    public void CreateASpellColliderFunction()
    {
        if(spellType == 0)
        {
            GameObject spellASpawn = Instantiate(SpellA, new Vector3(567, -27, 10), Quaternion.identity);
            GreenBossCharge.SetActive(true);
        }
        else if(spellType == 1)
        {
            GameObject spellBSpawn = Instantiate(SpellB, new Vector3(567, -26, 10), Quaternion.identity);
            PinkBossCharge.SetActive(true);
        }
        else if(spellType == 2)
        {
            GameObject spellCSpawn = Instantiate(SpellC, new Vector3(567, -25, 10), Quaternion.identity);
            YellowBossCharge.SetActive(true);
        }
        else if(spellType == 3)
        {
            GameObject spellDSpawn = Instantiate(SpellD, new Vector3(567, -24, 10), Quaternion.identity);
            RedBossCharge.SetActive(true);
        }
    }

    public void DestroySpellCollider()
    {
        Destroy(GameObject.Find("SpellA(Clone)"));
        Destroy(GameObject.Find("SpellB(Clone)"));
        Destroy(GameObject.Find("SpellC(Clone)"));
        Destroy(GameObject.Find("SpellD(Clone)"));
        // Search for a cube with a certain name and destroy it
        GreenBossCharge.SetActive(false);
        PinkBossCharge.SetActive(false);
        YellowBossCharge.SetActive(false);
        RedBossCharge.SetActive(false);
    }




    IEnumerator BossSpells()
    {
        
        switch (spellType)
        {
            case 0:
                GreenBossBolt.SetActive(true);
                yield return new WaitForSeconds(1);
                GreenBossBolt.SetActive(false);
                break;
            case 1:
                PinkBossBolt.SetActive(true);
                yield return new WaitForSeconds(1);
                PinkBossBolt.SetActive(false);
                break;
            case 2:
                YellowBossBolt.SetActive(true);
                yield return new WaitForSeconds(1);
                YellowBossBolt.SetActive(false);
                break;
            case 3:
                RedBossBolt.SetActive(true);
                yield return new WaitForSeconds(1);
                RedBossBolt.SetActive(false);
                break;
        }
        
    }
    
    
    
    
    IEnumerator introTextRoutine()
    {
        introText.SetActive(true);
        yield return new WaitForSeconds(10);
        introText.SetActive(false);
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
        yield return new WaitForSeconds(0.1f);
    }
     
    IEnumerator StopSinging()
    {
        animator.SetBool("IsSinging", false);
        characterController2D.canMove = true;
        characterController2D.invincible = false;
        yield return new WaitForSeconds(0.4f);
    }



    public void RandomDeathText()
    {
        RandomiseDeathText = Random.Range(0, 2);
    }

    public void MakeDeath()
    {
        RandomDeathText();
        StartCoroutine(Death());

        Debug.Log("RandomiseDeathText " + RandomiseDeathText);

        switch (RandomiseDeathText)
        {
            case 0:
                CharDeathText1.SetActive(true);
                break;
            case 1:
                CharDeathText2.SetActive(true);
                break;
            case 2:
                CharDeathText3.SetActive(true);
                break;
            
        }
        
        
        
        IEnumerator Death()
        {
            animator.SetBool("IsDead", true);
            characterController2D.canMove = false;
            characterController2D.invincible = true;
            yield return new WaitForSeconds(0.4f);
            characterController2D.m_Rigidbody2D.velocity = new Vector2(0, characterController2D.m_Rigidbody2D.velocity.y);
            yield return new WaitForSeconds(4f);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
