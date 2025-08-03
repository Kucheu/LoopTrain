using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public event Action<float> Damaged;
    public event Action<float> Healed;
    public event Action Death;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    private float maxHealth;
    private float currentHealth;


    public void SetHealt(float newHealth)
    {
        float change = newHealth - maxHealth;
        maxHealth = newHealth;
        currentHealth += change;
    }

    public void DealDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, MaxHealth);
        Damaged?.Invoke(damage);
        if(currentHealth <= 0f)
        {
            Death?.Invoke();
        }
    }

    public void Heal(float hp)
    {
        currentHealth = Mathf.Clamp(currentHealth + hp, 0, MaxHealth);
        Healed?.Invoke(hp);
    }
}
