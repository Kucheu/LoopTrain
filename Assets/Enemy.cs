using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> Death;

    [SerializeField]
    private HealthController healthController;

    public float Speed => speed;
    public Vector3 TargetPosition => target.transform.position;

    private float speed;
    private Base target;

    public void SetStats(float newHealth, float newSpeed)
    {
        healthController.SetHealt(newHealth);
        speed = newSpeed;
    }

    public void SetTarget(Base newTarget)
    {
        target = newTarget;
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
        Death?.Invoke(this);
        Destroy(gameObject);
    }
}

