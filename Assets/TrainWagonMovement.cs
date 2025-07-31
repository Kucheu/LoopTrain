using System;
using UnityEngine;
using UnityEngine.Splines;

public class TrainWagonMovement : MonoBehaviour
{
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private SplineContainer spline;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeBackForWagon;

    private float currentSplineTime;

    private void Update()
    {
        if (gameplayManager.CurrentGameState == GameState.Playing)
        {
            currentSplineTime += speed * Time.deltaTime;
            currentSplineTime %= 1f;
        }

        Vector3 x = spline.EvaluatePosition(currentSplineTime);
        Vector3 y = spline.EvaluatePosition(Mathf.Clamp(currentSplineTime + 0.01f, 0f, 1f));

        Vector3 relativePos = y - x;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = x;

    }

    internal Vector3 GetPositionForWagon(int wagonIndex)
    {
        float timeForWagon = Math.Abs(currentSplineTime - (timeBackForWagon * (wagonIndex + 1)));
        timeBackForWagon %= 1f;
        return spline.EvaluatePosition(timeForWagon);
    }
}
