using UnityEngine;

public class Zombie : Character
{
    [SerializeField]
    private ZombieData zombieData;
    private Health currentTarget;
    private void Start()
    {
        currentTarget = null;
    }
    private void Update()
    {
        if (health.IsDead) return;
        if (currentTarget == null)
        {
            Move();
        }
    }
    private void Move()
    {
        transform.Translate(Vector3.left * zombieData.moveSpeed * Time.deltaTime);
        characterAnimator.Play("Walk");
    }
}
