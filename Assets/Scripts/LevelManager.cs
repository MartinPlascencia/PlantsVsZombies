using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onLevelStart;
    [SerializeField]
    private EnemiesManager enemiesManager;
    [SerializeField]
    private CardsManager cardsManager;
    [SerializeField]
    private SkyboxManager skyboxManager;
    [SerializeField]
    private UnityEvent onLevelComplete;
    [SerializeField]
    private LevelsData levelsData;
    public void Initialize()
    {
        onLevelStart?.Invoke();
        LevelData currentLevel = levelsData.CurrentLevel;
        enemiesManager.SpawnEnemies(currentLevel.enemies);
        cardsManager.SetCards(currentLevel.cardLevels);
        skyboxManager.SetSkybox(currentLevel.skyboxMaterial);
    }
    public void CompleteLevel()
    {
        onLevelComplete?.Invoke();
    }
}
