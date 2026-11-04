using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onLevelStart;
    [SerializeField]
    private EnemiesManager enemiesManager;
    [SerializeField]
    private UnityEvent onLevelComplete;
    [SerializeField]
    private LevelsData levelsData;
    public void Initialize()
    {
        onLevelStart?.Invoke();
        enemiesManager.SpawnEnemies(levelsData.CurrentLevel.enemies);
    }
    public void CompleteLevel()
    {
        onLevelComplete?.Invoke();
    }
}
