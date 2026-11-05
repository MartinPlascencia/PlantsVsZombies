using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField]
    private LaneManager laneManager;
    [SerializeField]
    private UnityEvent onAllEnemiesDefeated;
    [SerializeField]
    private UnityEvent onEnemiesWin;
    private List<Zombie> currentEnemies = new List<Zombie>();
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
        zombie.onWin += EnemyWon;
        currentEnemies.Add(zombie);
        zombie.Initialize();
    }
    private void EnemyDied(Zombie zombie)
    {
        zombie.onDie -= EnemyDied;
        zombie.onWin -= EnemyWon;
        currentEnemies.Remove(zombie);
        currentEnemiesNumber--;
        if (currentEnemiesNumber <= 0)
        {
            onAllEnemiesDefeated?.Invoke();
        }
    }
    private void EnemyWon()
    {
        foreach (Zombie zombie in currentEnemies)
        {
            zombie.onWin -= EnemyWon;
            zombie.Win();
        }
        currentEnemies.Clear();
        currentEnemiesNumber = 0;
        onEnemiesWin?.Invoke();
    }

}
