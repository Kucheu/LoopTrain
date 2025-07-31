using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public event Action<float> Damaged;
    public event Action Death;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    private float maxHealth;
    private float currentHealth;


    public void SetHealt(float newHealth)
    {
        maxHealth = newHealth;
        currentHealth = newHealth;
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
}
