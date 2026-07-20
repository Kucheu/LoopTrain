using System.Collections;
using UnityEngine;

public class IntervalSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnInterval;
    [SerializeField]
    private EnemyData enemyToSpawn;
    [SerializeField]
    private int amountToSpawn;

    private WaitForSeconds waitForSpawn;
    private Coroutine spawnCoroutine;

    private void Awake()
    {
        waitForSpawn = new WaitForSeconds(spawnInterval);
    }


    private void OnEnable()
    {
        spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(spawnCoroutine);
    }

    private IEnumerator SpawnCoroutine()
    {
        while (gameObject.activeSelf)
        {
            yield return waitForSpawn;
            for (int i = 0; i < amountToSpawn; i++)
            {
                WaveManager.Instance.Spawn(enemyToSpawn, transform.position + new Vector3(UnityEngine.Random.Range(0.3f, 1f), UnityEngine.Random.Range(0.3f, 1f), 0));
            }
        }
    }
}
