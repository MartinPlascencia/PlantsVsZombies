using UnityEngine;
using System.Collections;
public class Bonk : AttackingPlant
{
    [SerializeField]
    private BonkData bonkData;
    protected override void Awake()
    {
        base.Awake();
        health.SetMaxHealth(bonkData.maxHealth);
        SetDetectionRange(bonkData.range);
    }
    protected override void OnEnable()
    {
        ClearTarget();
        base.OnEnable();
        Initialize();
    }
    protected override void PerformAttack(Health target)
    {
        SoundManager.instance.Play(bonkData.attackSound);
        StartCoroutine(AttackCoroutine(target));  
    }
    private IEnumerator AttackCoroutine(Health target)
    {
        characterAnimator.Play("Punch", 0, 0f);
        SoundManager.instance.Play(bonkData.attackSound);
        yield return new WaitForSeconds(bonkData.punchTime);
        if (target != null && !target.IsDead)
        {
            SoundManager.instance.Play(bonkData.punchSound);
            target.TakeDamage(bonkData.damage);
            PoolManager.Instance.GetObject(bonkData.hitParticles, 
                target.transform.position);
            if (target.IsDead)
            {
                ClearTarget();
            }
        }
        yield return new WaitForSeconds(bonkData.attackRate);
        SetCanAttack(true);
    }
    public override void Die()
    {
        SoundManager.instance.Play(bonkData.deathSound);
        base.Die();
    }
}
