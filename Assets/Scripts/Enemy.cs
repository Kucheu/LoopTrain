using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> Death;
    public static event Action<Enemy> Despawned;

    public event Action TargetSet;

    [SerializeField]
    private HealthController healthController;

    public float Speed => speed;
    public Vector3 TargetPosition => target;
    public MovementType MovementType => movementType;
    public float ExperienceMultiplayer => experienceMultiplayer;
    public float TimeFromLastMovement
    {
        get => timeFromLastMovement;
        set => timeFromLastMovement = value;
    }

    private float speed;
    private Vector3 target;
    private float damage = 25f;
    private MovementType movementType;
    private float timeFromLastMovement;
    private float experienceMultiplayer;

    public void SetStats(float newHealth, float newSpeed, MovementType newMovementType, float newExperienceMultiplayer)
    {
        healthController.SetHealt(newHealth);
        speed = newSpeed;
        movementType = newMovementType;
        experienceMultiplayer = newExperienceMultiplayer;
    }

    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
        Vector3 relativePos = target - transform.position;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        TargetSet?.Invoke();
    }

    private void OnEnable()
    {
        healthController.Death += OnDeath;
    }

    private void OnDisable()
    {
        healthController.Death -= OnDeath;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<HealthController>(out HealthController healthController))
        {
            healthController.DealDamage(damage);
            Despawn();
        }
    }

    private void OnDeath()
    {
        Death?.Invoke(this);
        Despawn();
    }

    private void Despawn()
    {
        Despawned?.Invoke(this);
        Destroy(gameObject);
    }
}

