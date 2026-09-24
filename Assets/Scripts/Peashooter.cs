using UnityEngine;

public class Peashooter : Character
{
    private void OnEnable()
    {
        health.SetMaxHealth(100);
        health.Initialize();
    }
}
