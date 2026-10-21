using UnityEngine;

public class FlowerZoneDetector : MonoBehaviour
{
    [SerializeField]
    private Collider zoneDetector;
    private Flower flower;
    public Flower Flower { set { flower = value; } }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zone"))
        {
            flower.AddZone(other.transform);
        }
    }
    public void ActivateDetector()
    {
        zoneDetector.enabled = true;
    }
    public void DeactivateDetector()
    {
        zoneDetector.enabled = false;
    }
}
