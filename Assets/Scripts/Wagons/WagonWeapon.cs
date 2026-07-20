using System;
using UnityEngine;

public abstract class WagonWeapon : MonoBehaviour
{
    public Action Shooted;

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
    protected float attackDistance;
    [SerializeField]
    protected LayerMask enemyLayerMask;

    private float currentTimeBetweenAttacks;

    public abstract void Attack();
}