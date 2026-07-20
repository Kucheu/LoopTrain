using UnityEngine;

public class NormalBullet : Bullet
{
    public override Vector3 Target => target.position;
    public override bool HasTarget => target != null;

    private Transform target;

    private bool isHit = false;

    public override void SetTarget(Transform target)
    {
        this.target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit)
            return;

        if (collision.transform.TryGetComponent(out HealthController healthController))
        {
            isHit = true;
            healthController.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
