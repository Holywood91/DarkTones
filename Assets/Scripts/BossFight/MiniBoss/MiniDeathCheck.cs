using UnityEngine;

public class MiniDeathCheck : MonoBehaviour
{
    public CapsuleCollider2D player;
    public MiniCreateSpellColliders minicreateSpellColliders;

    public ParticleSystem particleSystemPlayer;
    
    public GameObject GreenBossBolt;
    public GameObject PinkBossBolt;
    public GameObject YellowBossBolt;
    public GameObject RedBossBolt;

    public MiniBossFight miniBossFight;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider == player)
        {
            PlayParticleSystem();
            GreenBossBolt.SetActive(false);
            PinkBossBolt.SetActive(false);
            YellowBossBolt.SetActive(false);
            RedBossBolt.SetActive(false);
            minicreateSpellColliders.MakeDeath();
            miniBossFight.miniBossFightTimePassed = 30;
        }
    }

    void PlayParticleSystem()
    {
        particleSystemPlayer.Play();
    }
}
