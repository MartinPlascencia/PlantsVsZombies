using UnityEngine;
using System.Collections;

public class Peashooter : Character
{
    [SerializeField]
    private ShooterPlantData shooterPlantData;
    [SerializeField]
    private Transform shootPivot;
    private Health currentTarget;
    private DetectTarget detectTarget;
    private bool canAttack;
    protected override void Awake()
    {
        base.Awake();
        health.SetMaxHealth(shooterPlantData.maxHealth);
        detectTarget = GetComponent<DetectTarget>();
        detectTarget.SetRange(shooterPlantData.range);
    }
    private void OnEnable()
    {
        health.Initialize();
        currentTarget = null;
        canAttack = true;
        ActivateTargetDetection(true);
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
    private void OnTargetDetected(Health target)
    {
        if (target == currentTarget || target.IsDead) return;
        currentTarget = target;
    }
    private void Update()
    {
        if (health.IsDead) return;
        if (currentTarget != null && canAttack)
        {
            Attack();
        }
    }
    private void Attack()
    {
        canAttack = false;
        StartCoroutine(AttackRoutine());
    }
    private IEnumerator AttackRoutine()
    {
        if (currentTarget.IsDead)
        {
            currentTarget = null;
            canAttack = true;
            yield break;
        }
        characterAnimator.Play("Shoot", 0, 0f);
        yield return new WaitForSeconds(shooterPlantData.shootTime);
        GameObject bullet = PoolManager.Instance.GetObject(shooterPlantData.bulletPrefab, 
            shootPivot.position);
        bullet.SetActive(false);
        bullet.GetComponent<Bullet>().Damage = shooterPlantData.damage;
        bullet.transform.position = shootPivot.position;
        bullet.transform.rotation = shootPivot.rotation;
        bullet.SetActive(true);
        yield return new WaitForSeconds(shooterPlantData.fireRate);
        canAttack = true;
    }
}
