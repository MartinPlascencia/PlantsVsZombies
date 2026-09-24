using UnityEngine;

public class UILookCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }
}
