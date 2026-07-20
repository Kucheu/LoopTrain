using UnityEngine;

public class CanonBullet : Bullet
{
    [SerializeField]
    private AnimationCurve sizeCurve;

    public override Vector3 Target => target;
    public override bool HasTarget => true;

    private Vector3 target;
    private Vector3 startPosition;

    public override void SetTarget(Transform target)
    {
        startPosition = transform.position;
        this.target = target.position;
    }

    private void Update()
    {
        float currentDistancePercent = Vector3.Distance(startPosition, transform.position) / Vector3.Distance(startPosition, target);
        float size = sizeCurve.Evaluate(currentDistancePercent);
        transform.localScale = new Vector3(size, size, 1f);

        if(currentDistancePercent > 0.99f)
        {
            Debug.LogError("BOOOM");
            Remove();
        }
    }
}
