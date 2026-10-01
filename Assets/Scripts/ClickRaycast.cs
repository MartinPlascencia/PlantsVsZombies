using UnityEngine;
using UnityEngine.Events;

public class ClickRaycast : MonoBehaviour
{
    private float raycastDistance = 1000f;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private string sunTag;
    [SerializeField]
    private UnityEvent<int> onSunClicked;
    private bool isActive = true;
    public void SetActive(bool active)
    {
        isActive = active;
    }
    private void Update()
    {
        if (!isActive) return;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, layerMask))
            {
                if (hit.collider.CompareTag(sunTag))
                {
                    SunCollected(hit.collider.gameObject);
                }
            }
        }
    }
    private void SunCollected(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Sun>(out Sun sun))
        {
            sun.Collect();
            onSunClicked.Invoke(sun.Value);
        }
    }
}
