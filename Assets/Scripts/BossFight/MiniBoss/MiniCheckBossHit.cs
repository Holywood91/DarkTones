using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MiniCheckBossHit : MonoBehaviour
{
    public ParticleSystem bossParticleSystem;

    public int numberOfBossHits;

    public GameObject hitText2;
    public GameObject hitText3;

    public Animator BossAnimator;

    public ParticleSystem bossDeathParticleSystem;

    public SpriteRenderer bossSpriteRenderer;

    public GameObject HealthbarHit1;
    public GameObject HealthbarHit2;
    public GameObject HealthbarHit3;
    public GameObject HealthbarHit4;


    private void Awake()
    {
        hitText2.SetActive(false);
        hitText3.SetActive(false);
        
        HealthbarHit1.SetActive(false);
        HealthbarHit2.SetActive(false);
        HealthbarHit3.SetActive(false);
        HealthbarHit4.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(GameObject.Find("CharBoltGreen(Clone)"));
        Destroy(GameObject.Find("CharBoltPink(Clone)"));
        Destroy(GameObject.Find("CharBoltYellow(Clone)"));
        Destroy(GameObject.Find("CharBoltRed(Clone)"));
        PlayParticleSystem();
        StartCoroutine(BossHit());

        numberOfBossHits ++;
        
        if (numberOfBossHits == 1)
        {
            StartCoroutine(ShowHealthbarHit1());
        }
        
        if (numberOfBossHits == 2)
        {
            StartCoroutine(hitText1Routine());
            StartCoroutine(ShowHealthbarHit2());
        }
        
        if (numberOfBossHits == 3)
        {
            StartCoroutine(ShowHealthbarHit3());
        }
        
        if (numberOfBossHits == 4)
        {
            StartCoroutine(hitText2Routine());
            StartCoroutine(ShowHealthbarHit4());
        }

    }

    void PlayParticleSystem()
    {
        bossParticleSystem.Play();
    }

    IEnumerator hitText1Routine()
    {
        hitText2.SetActive(true);
        yield return new WaitForSeconds(5);
        hitText2.SetActive(false);
    }

    
    IEnumerator hitText2Routine()
    {
        hitText3.SetActive(true);
        yield return new WaitForSeconds(10);
        hitText3.SetActive(false);
        BossAnimator.SetBool("IsDead", true);
        yield return new WaitForSeconds(1);
        bossDeathParticleSystem.Play();
        Destroy(bossSpriteRenderer);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Level2");
        
    }

    IEnumerator BossHit()
    {
        bossSpriteRenderer.material.color = Color.red;
        yield return new  WaitForSeconds(0.1f);
        bossSpriteRenderer.material.color = Color.white;
    }

    IEnumerator ShowHealthbarHit1()
    {
        HealthbarHit1.SetActive(true);
        yield return new WaitForSeconds(2);
        HealthbarHit1.SetActive(false);
    }

    IEnumerator ShowHealthbarHit2()
    {
        HealthbarHit2.SetActive(true);
        yield return new WaitForSeconds(2);
        HealthbarHit2.SetActive(false);
    }

    IEnumerator ShowHealthbarHit3()
    {
        HealthbarHit3.SetActive(true);
        yield return new WaitForSeconds(2);
        HealthbarHit3.SetActive(false);
    }

    IEnumerator ShowHealthbarHit4()
    {
        HealthbarHit4.SetActive(true);
        yield return new WaitForSeconds(2);
        HealthbarHit4.SetActive(false);
    }
}
