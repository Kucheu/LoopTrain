using System;
using UnityEngine;

public class Reproduction : MonoBehaviour
{
    [SerializeField]
    private HealthController healthController;
    [SerializeField]
    private EnemyData enemyToSpawn;

    private void OnEnable()
    {
        healthController.Death += OnDeath;
    }

    private void OnDisable()
    {
        healthController.Death -= OnDeath;
    }

    private void OnDeath()
    {
        for(int i = 0; i < 3; i++)
        {
            WaveManager.Instance.Spawn(enemyToSpawn, transform.position + new Vector3(UnityEngine.Random.Range(0.3f, 1f), UnityEngine.Random.Range(0.3f, 1f), 0));
        }
    }
}
