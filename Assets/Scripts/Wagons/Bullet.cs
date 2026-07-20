using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public static event Action<Bullet> OnBulletSpawned;
    public static event Action<Bullet> OnBulletDespawned;

    [SerializeField]
    private float speed;

    public abstract Vector3 Target { get; }
    public float Speed => speed;

    public abstract bool HasTarget { get; }

    protected float damage;

    private void OnEnable()
    {
        OnBulletSpawned?.Invoke(this);
    }

    private void OnDisable()
    {
        OnBulletDespawned?.Invoke(this);
    }

    public abstract void SetTarget(Transform target);

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}