using UnityEngine;

public class ShootSound : MonoBehaviour
{
    [SerializeField]
    private WagonWeapon wagonWeapon;
    [SerializeField]
    private AudioClip shootSound;

    private void OnEnable()
    {
        wagonWeapon.Shooted += OnShoot;    
    }

    private void OnDisable()
    {
        wagonWeapon.Shooted += OnShoot;
    }

    private void OnShoot()
    {
        SoundManager.Instance.PlaySound(shootSound);
    }
}
