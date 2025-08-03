using System;
using UnityEngine;

public class DamageSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private HealthController healthController;

    private void OnEnable()
    {
        healthController.Damaged += OnDamage;
    }

    private void OnDisable()
    {
        healthController.Damaged += OnDamage;
    }

    private void OnDamage(float obj)
    {
        SoundManager.Instance.PlaySound(audioClip);
    }
}
