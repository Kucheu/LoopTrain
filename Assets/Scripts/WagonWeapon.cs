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

    private float currentTimeBetweenAttacks;

    public abstract void Attack();
}