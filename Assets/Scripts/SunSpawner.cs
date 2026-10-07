using UnityEngine;
using System.Collections;

public class SunSpawner : MonoBehaviour
{
    [SerializeField]
    private LaneManager laneManager;
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private float offsetY;
    [SerializeField]
    private GameObject sunPrefab;
    private bool isActive;
    public void Activate(bool active)
    {
        isActive = active;
        if (isActive)
        {
            StartCoroutine(SpawnSuns());
        }
        else
        {
            StopCoroutine(SpawnSuns());
        }
    }
    private IEnumerator SpawnSuns()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            Lane lane = laneManager.GetRandomLane();
            Transform zone = lane.GetRandomZone();
            Vector3 spawnPosition = zone.position + new Vector3(0, offsetY, 0);
            PoolManager.Instance.GetObject(sunPrefab, spawnPosition);
        }
    }

}
