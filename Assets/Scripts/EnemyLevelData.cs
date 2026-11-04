using UnityEngine;

[System.Serializable]
public class EnemyLevelData
{
    public EnemyData[] enemies;
}

[System.Serializable]
public class EnemyData
{
    public GameObject enemyPrefab;
    public float spawnTime;
    public int laneIndex;
}
