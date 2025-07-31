using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static event Action<Bullet> OnBulletSpawned;
    public static event Action<Bullet> OnBulletDespawned;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;

    public float Speed => speed;

    private bool isHit = false;

    private void OnEnable()
    {
        OnBulletSpawned?.Invoke(this);
    }

    private void OnDisable()
    {
        OnBulletDespawned?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
            return;

        if (collision.transform.TryGetComponent(out HealthController healthController))
        {
            isHit = true;
            healthController.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}