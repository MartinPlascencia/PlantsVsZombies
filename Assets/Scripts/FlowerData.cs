using UnityEngine;

[CreateAssetMenu(fileName = "FlowerData", menuName = "Scriptable Objects/FlowerData")]
public class FlowerData : PlantData
{
    public GameObject sunPrefab;
    public float sunOffsetY;
    public float sunInterval;
    public int sunAmount;
    public GameObject sunParticlePrefab;
}
