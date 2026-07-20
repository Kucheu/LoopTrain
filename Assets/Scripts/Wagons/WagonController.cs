using System;
using UnityEngine;

public class WagonController : MonoBehaviour
{
    public static event Action<WagonController> WagonSpawned;
    public static event Action<WagonController> WagonDespawned;

    private void OnEnable()
    {
        WagonSpawned?.Invoke(this);
    }

    private void OnDisable()
    {
        WagonDespawned?.Invoke(this);
    }

    [SerializeField]
    private WagonWeapon wagonWeapon;

    public WagonWeapon WagonWeapon => wagonWeapon;

    internal void SetPosition(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
}
