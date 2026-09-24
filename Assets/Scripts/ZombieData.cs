using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "Scriptable Objects/ZombieData")]
public class ZombieData : ScriptableObject
{
    public float maxHealth;
    public float moveSpeed;
    public float damage;
    public float attackRange;
    public float attackCooldown;
    public float hitTime;
}
