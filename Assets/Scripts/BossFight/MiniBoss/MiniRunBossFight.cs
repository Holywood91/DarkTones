using UnityEngine;

public class MiniRunBossFight : MonoBehaviour
{
    public GameObject miniBossFightObject;
    private MiniBossFight miniBossFight;
    public GameObject miniCreateSpellCollidersObject;
    private MiniCreateSpellColliders miniCreateSpellColliders;
    
    void Awake()
    {
        miniBossFight = miniBossFightObject.GetComponent<MiniBossFight>();
        miniCreateSpellColliders = miniCreateSpellCollidersObject.GetComponent<MiniCreateSpellColliders>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        miniBossFight.MiniBossFightFunction();
        miniCreateSpellColliders.CreateSpellColliderTypes();
    }
}
