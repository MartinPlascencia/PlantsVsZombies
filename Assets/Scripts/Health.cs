using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private UnityEvent onDeath;
    [SerializeField]
    private UnityEvent onTakeDamage;
    private float currentHealth;
    private float maxHealth;
    public bool IsDead => currentHealth <= 0;
    public void SetMaxHealth(float health)
    {
        maxHealth = health;
    }
    public void Initialize()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
    }
    private void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth / maxHealth;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        onTakeDamage?.Invoke();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            onDeath?.Invoke();
        }
        UpdateHealthSlider();
    }
}
