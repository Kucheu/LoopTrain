using System;
using UnityEngine;

public class DamageShower : MonoBehaviour
{
    [SerializeField]
    private HealthController healthController;

    private void OnEnable()
    {
        healthController.Damaged += ShowDamage;
    }

    private void OnDisable()
    {
        healthController.Damaged -= ShowDamage;
    }

    private void ShowDamage(float damage)
    {
        DamageUIManager.Instance.ShowDamage(transform.position, (int)damage);
    }
}
