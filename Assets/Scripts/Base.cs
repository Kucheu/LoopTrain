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
        gameplayManager.RemoveBase(this);
        Debug.LogError("Despawn");
    }
}
