using UnityEngine;

public class DetectTarget : MonoBehaviour
{
    [SerializeField]
    private string targetTag;
    private float range;
    private bool isActive;
    private System.Action<Transform> onTargetDetected;
    public System.Action<Transform> OnTargetDetected => onTargetDetected;
    public void SetRange(float newRange)
    {
        range = newRange;
    }
    public void SetActive(bool newActive)
    {
        isActive = newActive;
    }
    private void Update()
    {
        if (!isActive) return;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, range))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                onTargetDetected?.Invoke(hit.transform);
            }
        }
        
    }

}
