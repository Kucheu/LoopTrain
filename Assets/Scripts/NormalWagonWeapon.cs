using UnityEngine;

public class NormalWagonWeapon : WagonWeapon
{
    [SerializeField]
    private Bullet bulletPrefab;
    [SerializeField]
    private float attackDistance;
    [SerializeField]
    private LayerMask enemyLayerMask;

    public override void Attack()
    {
        var target = Physics2D.OverlapCircle(transform.position, attackDistance, enemyLayerMask);
        if(target != null)
        {
            Vector3 relativePos = target.transform.position - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            var bullet = Instantiate(bulletPrefab, transform.position, rotation);
            bullet.SetTarget(target.transform);
        }
        
    }
}