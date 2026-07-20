using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class SpawnerOnTargetChange : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyToSpawn;

    private WaitForSeconds waitToSpawn;
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        waitToSpawn = new WaitForSeconds(1f);
    }

    private void OnEnable()
    {
        enemy.TargetSet += OnTargetSet;

    }

    private void OnDisable()
    {
        enemy.TargetSet -= OnTargetSet;
    }

    private void OnTargetSet()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return waitToSpawn;
        WaveManager.Instance.Spawn(enemyToSpawn, transform.position + new Vector3(UnityEngine.Random.Range(0.3f, 1f), UnityEngine.Random.Range(0.3f, 1f), 0));

    }
}
