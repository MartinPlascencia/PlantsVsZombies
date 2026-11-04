using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField]
    private LaneManager laneManager;
    [SerializeField]
    private UnityEvent onAllEnemiesDefeated;
    private int currentEnemiesNumber;
    public void SpawnEnemies(EnemyData[] enemies)
    {
        currentEnemiesNumber = enemies.Length;
        foreach (EnemyData enemy in enemies)
        {
            StartCoroutine(SpawnEnemy(enemy));
        }
    }
    private IEnumerator SpawnEnemy(EnemyData enemy)
    {
        yield return new WaitForSeconds(enemy.spawnTime);
        Lane lane = laneManager.GetLane(enemy.laneIndex);
        Zombie zombie = PoolManager.Instance.GetObject(enemy.enemyPrefab, 
            lane.LaneStart.position).GetComponent<Zombie>();
        zombie.onDie += EnemyDied;
        zombie.Initialize();
    }
    private void EnemyDied(Zombie zombie)
    {
        zombie.onDie -= EnemyDied;
        currentEnemiesNumber--;
        if (currentEnemiesNumber <= 0)
        {
            onAllEnemiesDefeated?.Invoke();
        }
    }

}
