using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onLevelStart;
    private void Start()
    {
        onLevelStart?.Invoke();
    }
}
