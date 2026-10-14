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
    protected override void OnEnable()
    {
        currentTarget = null;
        base.OnEnable();
        //SoundManager.instance.Play(shooterPlantData.appearSound);
        health.Initialize();
    }
    public override void Initialize()
    {
        base.Initialize();
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
        SoundManager.instance.Play(shooterPlantData.attackSound);
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
            shootPivot.position, true);
        //bullet.SetActive(false);
        bullet.GetComponent<Bullet>().Damage = shooterPlantData.damage;
        bullet.transform.position = shootPivot.position;
        bullet.transform.rotation = shootPivot.rotation;
        bullet.SetActive(true);
        yield return new WaitForSeconds(shooterPlantData.fireRate);
        canAttack = true;
    }
    public override void Die()
    {
        ActivateTargetDetection(false);
        SoundManager.instance.Play(shooterPlantData.deathSound);
        base.Die();
    }
}
