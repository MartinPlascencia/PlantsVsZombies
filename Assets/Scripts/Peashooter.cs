using UnityEngine;
using System.Collections;

public class Peashooter : AttackingPlant
{
    [SerializeField]
    private ShooterPlantData shooterPlantData;
    [SerializeField]
    private Transform shootPivot;
    protected override void Awake()
    {
        base.Awake();
        health.SetMaxHealth(shooterPlantData.maxHealth);
        SetDetectionRange(shooterPlantData.range);
    }
    protected override void OnEnable()
    {
        ClearTarget();
        base.OnEnable();
        SoundManager.instance.Play(shooterPlantData.appearSound);
        health.Initialize();
    }
    protected override void PerformAttack(Health target)
    {
        SoundManager.instance.Play(shooterPlantData.attackSound);
        StartCoroutine(AttackRoutine(target));
    }
    
    private IEnumerator AttackRoutine(Health target)
    {
        if (target == null || target.IsDead)
        {
            SetCanAttack(true);
            yield break;
        }
        characterAnimator.Play("Shoot", 0, 0f);
        yield return new WaitForSeconds(shooterPlantData.shootTime);
        if (target != null && !target.IsDead)
        {
            for (int i = 0; i < shooterPlantData.numberOfBullets; i++)
            {
                GameObject bullet = PoolManager.Instance.GetObject(shooterPlantData.bulletPrefab, 
                    shootPivot.position, true);
                bullet.GetComponent<Bullet>().Damage = shooterPlantData.damage;
                bullet.transform.position = shootPivot.position;
                bullet.transform.rotation = shootPivot.rotation;
                bullet.SetActive(true);
                if (i != shooterPlantData.numberOfBullets - 1)
                {
                    yield return new WaitForSeconds(shooterPlantData.shotBulletsDelay);
                }
            }
        }
        yield return new WaitForSeconds(shooterPlantData.fireRate);
        SetCanAttack(true);
    }
    public override void Die()
    {
        SoundManager.instance.Play(shooterPlantData.deathSound);
        base.Die();
    }
}
