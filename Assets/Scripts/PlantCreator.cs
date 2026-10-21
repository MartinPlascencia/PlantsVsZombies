using UnityEngine;

public class PlantCreator : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance;
    [SerializeField]
    private LayerMask plantLayer;
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
            if (!objectPlaced || currentZone == null || currentZone.IsOccupied)
            {
                objectToPlace.gameObject.SetActive(false);
            }
            else
            {
                Plant plant = objectToPlace.GetComponent<Plant>();
                plant.SetZone(currentZone);
                plant.Initialize();
            }
            objectToPlace = null;
        }
    }
    public void SetObjectToPlace(Transform obj)
    {
        objectToPlace = obj;
        objectPlaced = false;
        currentZone = null;
    }
}
