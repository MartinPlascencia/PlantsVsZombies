using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "Scriptable Objects/PlantData")]
public class PlantData : ScriptableObject
{
    public string appearSound;
    public string attackSound;
    public string deathSound;
    public float maxHealth;
}
