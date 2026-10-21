using UnityEngine;

public class Wallnut : Plant
{
    [SerializeField]
    private float maxHealth;
    protected override void Awake()
    {
        base.Awake();
        health.SetMaxHealth(maxHealth);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        health.Initialize();
    }
}