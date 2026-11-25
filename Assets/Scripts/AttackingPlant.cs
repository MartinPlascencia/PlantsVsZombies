using UnityEngine;
public abstract class AttackingPlant : Plant
{
    protected DetectTarget detectTarget;
    private Health currentTarget;
    private bool canAttack;
    protected Health CurrentTarget => currentTarget;
    protected override void Awake()
    {
        base.Awake();
        detectTarget = GetComponent<DetectTarget>();
    }
    protected void SetDetectionRange(float range)
    {
        detectTarget.SetRange(range);
    }
    protected void ClearTarget()
    {
        currentTarget = null;
    }
    public override void Initialize()
    {
        base.Initialize();
        canAttack = true;
        ActivateTargetDetection(true);
    }
    private void ActivateTargetDetection(bool activate)
    {
        detectTarget.SetActive(activate);
        detectTarget.OnTargetDetected -= OnTargetDetected;
        if (activate)
            detectTarget.OnTargetDetected += OnTargetDetected;
    }
    private void OnTargetDetected(Health target)
    {
        if (target == null || target == currentTarget || target.IsDead)
        {
            return;
        }
        currentTarget = target;
    }
    protected void Update()
    {
        if (health.IsDead || !canAttack) return;
        if (currentTarget == null || currentTarget.IsDead) return;
        canAttack = false;
        PerformAttack(currentTarget);
    }
    protected abstract void PerformAttack(Health target);
    protected void SetCanAttack(bool value)
    {
        canAttack = value;
    }
    public override void Die()
    {
        ActivateTargetDetection(false);
        base.Die();
    }
}
