using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class PlantCreator : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance;
    [SerializeField]
    private LayerMask plantLayer;
    [SerializeField]
    private SunManager sunManager;
    [SerializeField]
    private UnityEvent onPlantPlaced;
    [SerializeField]
    private UnityEvent onPlantCancelled;
    [SerializeField]
    private GameObject plantPlacesParticlesPrefab;
    private List<Plant> plants = new List<Plant>();
    private Transform objectToPlace;
    private bool objectPlaced;
    private Zone currentZone;
    private void Update()
    {
        if (objectToPlace == null) return;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, plantLayer))
            {
                if (hit.collider.CompareTag("Zone"))
                {
                    currentZone = hit.collider.GetComponent<Zone>();
                    objectToPlace.position = hit.collider.transform.position;
                    objectPlaced = true;
                }
                else
                {
                    if (hit.collider.CompareTag("Floor"))
                    {
                        objectToPlace.position = hit.point;
                    }
                    objectPlaced = false;
                    currentZone = null;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Plant plant = objectToPlace.GetComponent<Plant>();
            if (!objectPlaced || currentZone == null || currentZone.IsOccupied)
            {
                objectToPlace.gameObject.SetActive(false);
                sunManager.AddSun(plant.Price);
                onPlantCancelled?.Invoke();
            }
            else
            {
                onPlantPlaced?.Invoke();
                plant.SetZone(currentZone);
                plant.Initialize();
                plants.Add(plant);
                PoolManager.Instance.GetObject(plantPlacesParticlesPrefab, objectToPlace.position);
            }
            objectToPlace = null;
        }
    }
    public void StopPlants()
    {
        foreach (Plant plant in plants)
        {
            plant.gameObject.SetActive(false);
        }
    }
    public void SetObjectToPlace(Transform obj)
    {
        objectToPlace = obj;
        objectPlaced = false;
        currentZone = null;
    }
}
