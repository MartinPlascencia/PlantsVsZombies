using UnityEngine;

[CreateAssetMenu(fileName = "ShooterPlantData", menuName = "Scriptable Objects/ShooterPlantData")]
public class ShooterPlantData : PlantData
{
    public float damage;
    public float range;
    public GameObject attackParticles;
    public GameObject bulletPrefab;
    public float shootTime;
    public float fireRate;

}
