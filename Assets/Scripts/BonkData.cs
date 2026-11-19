using UnityEngine;

[CreateAssetMenu(fileName = "BonkData", menuName = "Scriptable Objects/BonkData")]
public class BonkData : PlantData
{
    public GameObject hitParticles;
    public float damage;
    public float range;
    public float attackRate;
    public string punchSound;
    public float punchTime = 1f;
}
