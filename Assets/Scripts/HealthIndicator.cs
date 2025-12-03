using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField]
    private List<IndicatorToDamagePercent> damageIndicators;
    [SerializeField]
    private HealthController healthController;

    private void OnEnable()
    {
        healthController.Damaged += OnHealthChange;
        healthController.Healed += OnHealthChange;
    }

    private void OnDisable()
    {
        healthController.Damaged -= OnHealthChange;
        healthController.Healed -= OnHealthChange;
    }

    private void OnHealthChange(float obj)
    {
        float healthPercent = healthController.CurrentHealth / healthController.MaxHealth;
        foreach (var indicator in damageIndicators)
        {
            indicator.indicator.SetActive(healthPercent <= indicator.damage);
        }
    }
    [ContextMenu("damage")]
    private void DeadDamage()
    {
        healthController.DealDamage(20f);
    }

    [Serializable]
    struct IndicatorToDamagePercent
    {
        [SerializeField, Range(0f, 1f)]
        public float damage;
        public GameObject indicator;
    }
}
