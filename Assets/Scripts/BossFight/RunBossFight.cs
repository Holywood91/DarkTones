using UnityEngine;

public class RunBossFight : MonoBehaviour
{
    public GameObject BossFightObject;
    private BossFight BossFight;
    public GameObject CreateSpellCollidersObject;
    private CreateSpellColliders CreateSpellColliders;
    
    void Awake()
    {
        BossFight = BossFightObject.GetComponent<BossFight>();
        CreateSpellColliders = CreateSpellCollidersObject.GetComponent<CreateSpellColliders>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        BossFight.BossFightFunction();
        CreateSpellColliders.CreateSpellColliderTypes();
    }
}
