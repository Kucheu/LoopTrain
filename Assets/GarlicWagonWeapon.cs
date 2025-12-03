using UnityEngine;

public class GarlicWagonWeapon : WagonWeapon
{
    [SerializeField]
    private GameObject effectObject;

    private void Awake()
    {
        effectObject.transform.localScale = new Vector3(attackDistance * 2, attackDistance * 2, 1f);
    }

    public override void Attack()
    {
        var targets = Physics2D.OverlapCircleAll(transform.position, attackDistance, enemyLayerMask);
        if (targets.Length > 0)
        {
            foreach (var target in targets)
            {
                if (target.transform.TryGetComponent(out HealthController healthController))
                {
                    healthController.DealDamage(damage * StatsManager.Instance.DamageMultiplier);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, attackDistance);
    }
}
