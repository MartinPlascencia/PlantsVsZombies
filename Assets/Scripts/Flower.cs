using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flower : Character
{
    [SerializeField]
    private Collider zoneDetector;
    [SerializeField]
    private FlowerData flowerData;
    private List<Transform> zones = new List<Transform>();
    protected override void Awake()
    {
        base.Awake();
        health.SetMaxHealth(flowerData.maxHealth);
    }
    protected override void OnEnable()
    {
        zoneDetector.enabled = false;
        zones.Clear();
        base.OnEnable();
        //SoundManager.instance.Play(flowerData.appearSound);
    }
    public override void Initialize()
    {
        base.Initialize();
        zoneDetector.enabled = true;
        StartCoroutine(GenerateSun());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zone"))
        {
            zones.Add(other.transform);
        }
    }
    private IEnumerator GenerateSun()
    {
        while (!health.IsDead)
        {
            yield return new WaitForSeconds(flowerData.sunInterval);
            if (zones.Count > 0)
            {
                for (int i = 0; i < flowerData.sunAmount; i++)
                {
                    Transform zone = zones[Random.Range(0, zones.Count)];
                    PoolManager.Instance.GetObject(flowerData.sunPrefab, 
                        zone.position + Vector3.up * flowerData.sunOffsetY); 
                }
                SoundManager.instance.Play(flowerData.attackSound);
                characterAnimator.Play("Attack", 0, 0f);
                PoolManager.Instance.GetObject(flowerData.sunParticlePrefab, 
                    transform.position);
            }
        }
    }
    public override void Die()
    {
        base.Die();
        SoundManager.instance.Play(flowerData.deathSound);
        zoneDetector.enabled = false;
    }
    

}
