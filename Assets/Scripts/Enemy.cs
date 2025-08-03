using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> Death;
    public static event Action<Enemy> Despawned;

    [SerializeField]
    private HealthController healthController;

    public float Speed => speed;
    public Vector3 TargetPosition => target.transform.position;

    private float speed;
    private Base target;
    private float damage = 25f;

    public void SetStats(float newHealth, float newSpeed)
    {
        healthController.SetHealt(newHealth);
        speed = newSpeed;
    }

    public void SetTarget(Base newTarget)
    {
        target = newTarget;
        Vector3 relativePos = target.transform.position - transform.position;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnEnable()
    {
        healthController.Death += OnDeath;
    }

    private void OnDisable()
    {
        healthController.Death -= OnDeath;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<HealthController>(out HealthController healthController))
        {
            healthController.DealDamage(damage);
            Despawn();
        }
    }

    private void OnDeath()
    {
        Death?.Invoke(this);
        Despawn();
    }

    private void Despawn()
    {
        Despawned?.Invoke(this);
        Destroy(gameObject);
    }
}

