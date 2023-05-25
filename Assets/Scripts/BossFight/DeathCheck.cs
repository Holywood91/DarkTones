using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    public CapsuleCollider2D player;
    public CreateSpellColliders createSpellColliders;

    public ParticleSystem particleSystemPlayer;
    
    public GameObject GreenBossBolt;
    public GameObject PinkBossBolt;
    public GameObject YellowBossBolt;
    public GameObject RedBossBolt;

    public BossFight bossFight;
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider == player)
        {
            PlayParticleSystem();
            GreenBossBolt.SetActive(false);
            PinkBossBolt.SetActive(false);
            YellowBossBolt.SetActive(false);
            RedBossBolt.SetActive(false);
            createSpellColliders.MakeDeath();
            bossFight.bossFightTimePassed = 30;
        }
    }

    void PlayParticleSystem()
    {
        particleSystemPlayer.Play();
    }
}
