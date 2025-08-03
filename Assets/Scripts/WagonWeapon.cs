using UnityEngine;

public abstract class WagonWeapon : MonoBehaviour
{
    public float Cooldown => cooldown;
    public float CurrentTimeBetweenAttacks
    {
        get => currentTimeBetweenAttacks;
        set => currentTimeBetweenAttacks = value;
    }

    [SerializeField]
    private float cooldown;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected Bullet bulletPrefab;
    [SerializeField]
    protected float attackDistance;
    [SerializeField]
    protected LayerMask enemyLayerMask;
    [SerializeField]
    protected GameObject weapon;

    private float currentTimeBetweenAttacks;

    public abstract void Attack();
}