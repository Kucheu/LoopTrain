using System.Collections.Generic;
using UnityEngine;

public class WagonWeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameplayManager gameplayManager;

    private List<WagonController> wagonControllers;
    private List<Bullet> bullets;

    private void Awake()
    {
        wagonControllers = new();
        bullets = new();
    }

    private void OnEnable()
    {
        Bullet.OnBulletSpawned += AddBullet;
        Bullet.OnBulletDespawned += RemoveBullet;
        WagonController.WagonSpawned += AddWagon;
        WagonController.WagonDespawned += RemoveWagon;
    }

    private void OnDisable()
    {
        Bullet.OnBulletSpawned -= AddBullet;
        Bullet.OnBulletDespawned -= RemoveBullet;
        WagonController.WagonSpawned -= AddWagon;
        WagonController.WagonDespawned -= RemoveWagon;
    }

    private void Update()
    {
        if (gameplayManager.CurrentGameState != GameState.Playing)
            return;

        ManageWagonsWeapons();
        ManageBullets();
    }

    private void ManageBullets()
    {
        foreach (var bullet in bullets)
        {
            bullet.transform.position += (bullet.transform.right * bullet.Speed * Time.deltaTime);
        }
    }

    private void ManageWagonsWeapons()
    {
        foreach (var wagon in wagonControllers)
        {
            wagon.WagonWeapon.CurrentTimeBetweenAttacks += Time.deltaTime;
            if (wagon.WagonWeapon.CurrentTimeBetweenAttacks >= wagon.WagonWeapon.Cooldown)
            {
                wagon.WagonWeapon.CurrentTimeBetweenAttacks = 0f;
                wagon.WagonWeapon.Attack();
            }
        }
    }

    private void RemoveWagon(WagonController obj)
    {
        wagonControllers.Remove(obj);
    }

    private void AddWagon(WagonController obj)
    {
        wagonControllers.Add(obj);
    }

    private void RemoveBullet(Bullet obj)
    {
        bullets.Remove(obj);
    }

    private void AddBullet(Bullet obj)
    {
        bullets.Add(obj);
    }
}
