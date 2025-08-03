using System;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private float startingHP;
    [SerializeField]
    private HealthController healthController;

    private bool isDead;

    public bool IsDead => isDead;

    private void Awake()
    {
        healthController.SetHealt(startingHP);
    }

    private void OnEnable()
    {
        healthController.Death += OnDeath;
    }

    private void OnDisable()
    {
        healthController.Death -= OnDeath;
    }

    private void OnDeath()
    {
        isDead = true;
        gameplayManager.RemoveBase(this);
        Debug.LogError("Despawn");
    }

    internal void UpdateHealth()
    {
        healthController.SetHealt(startingHP * StatsManager.Instance.MaxHp);
    }
}
