using UnityEngine;
using System.Collections;
public class Zombie : Character
{
    [SerializeField]
    private ZombieData zombieData;
    private DetectTarget detectTarget;
    private Health currentTarget;
    private bool canAttack;
    protected override void Awake()
    {
        base.Awake();
        health.SetMaxHealth(zombieData.maxHealth);
        detectTarget = GetComponent<DetectTarget>();
        detectTarget.SetRange(zombieData.attackRange);
    }
    public override void Die()
    {
        ActivateTargetDetection(false);
        SoundManager.instance.Play(zombieData.deathSound);
        base.Die();
    }
    private void OnEnable()
    {
        SoundManager.instance.Play(zombieData.appearSound);
        currentTarget = null;
        canAttack = true;
        ActivateTargetDetection(true);
        health.Initialize();
    }
    private void ActivateTargetDetection(bool isActive)
    {
        detectTarget.SetActive(isActive);
        if (isActive)
        {
            detectTarget.OnTargetDetected += OnTargetDetected;
        }
        else
        {
            detectTarget.OnTargetDetected -= OnTargetDetected;
        }
    }
    private void Update()
    {
        if (health.IsDead) return;
        if (currentTarget == null)
        {
            Move();
        }
        else
        {
            Attack();
        }
    }
    private void Attack()
    {
        if (!canAttack) return;
        StartCoroutine(PerformAttack());
    }
    private IEnumerator PerformAttack()
    {
        canAttack = false;
        SoundManager.instance.Play(zombieData.attackSound);
        characterAnimator.Play("Attack", 0, 0f);
        yield return new WaitForSeconds(zombieData.attackCooldown);
        currentTarget.TakeDamage(zombieData.damage);
        PoolManager.Instance.GetObject(zombieData.attackParticles, currentTarget.transform.position);
        if (currentTarget.IsDead) currentTarget = null;
        yield return new WaitForSeconds(zombieData.attackCooldown);
        canAttack = true;
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * zombieData.moveSpeed * Time.deltaTime);
        characterAnimator.Play("Walk");
    }
    private void OnTargetDetected(Health target)
    {
        if(target.IsDead || currentTarget == target) return;
        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            float newDistance = Vector3.Distance(transform.position, currentTarget.transform.position);
            if (newDistance > distance)
            {
                currentTarget = target;
                return;
            }
        }
        currentTarget = target;
    }
}
