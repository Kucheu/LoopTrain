using UnityEngine;

public class ShotgunWagonWeapon : WagonWeapon
{
    public override void Attack()
    {
        var target = Physics2D.OverlapCircle(transform.position, attackDistance, enemyLayerMask);
        if (target != null)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            angle -= 20;
            Quaternion rotation;
            for (int i = 0; i < 3; i++)
            {
                rotation = Quaternion.AngleAxis(angle + (20 * i), Vector3.forward);
                var bullet = Instantiate(bulletPrefab, transform.position, rotation);
                bullet.SetDamage(damage * StatsManager.Instance.DamageMultiplier);
            }
            rotation = Quaternion.AngleAxis(angle + 20, Vector3.forward);
            weapon.transform.rotation = rotation;
            Shooted?.Invoke();
        }
    }
}
