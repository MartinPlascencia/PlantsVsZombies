using UnityEngine;

[CreateAssetMenu(fileName = "LevelsData", menuName = "Scriptable Objects/LevelsData")]
public class LevelsData : ScriptableObject
{
    public LevelData[] levels;
    [SerializeField]
    private int currentIndex;
    public int CurrentIndex => currentIndex;
    public LevelData CurrentLevel => levels[currentIndex];
}

[System.Serializable]
public class LevelData
{
    public EnemyData[] enemies;
}
