using System;
using System.Collections.Generic;
using UnityEngine;


public class WaveManager : MonoBehaviourSingleton<WaveManager>
{
    [SerializeField]
    private List<EnemyData> enemies;
    [SerializeField]
    private List<BossSpawnData> bosses;
    [SerializeField]
    private float timeBetweenSpawns;
    [SerializeField]
    private float distanceFromCenter;
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private TimerManager timerManager;

    public List<Enemy> SpawnedEnemies => spawnedEnemies;

    private float timeFromLastSpawn;
    private List<Enemy> spawnedEnemies;
    private List<Enemy> spawnedBosses;

    private new void Awake()
    {
        base.Awake();
        spawnedEnemies = new();
        spawnedBosses = new();
    }

    private void OnEnable()
    {
        Enemy.Despawned += OnEnemyDespawn;
    }

    private void OnDisable()
    {
        Enemy.Despawned -= OnEnemyDespawn;
    }

    private void Update()
    {
        if (gameplayManager.CurrentGameState != GameState.Playing)
            return;

        CheckBossesToSpawn();

        if (!IsBossPrevent() && CheckSpawn())
        {
            var enemyDataToSpawn = enemies[UnityEngine.Random.Range(0, enemies.Count)];
            int numberEnemiesToSpawn = UnityEngine.Random.Range(1 + (int)Math.Floor(timerManager.CurrentTime / 60f), 2 + (int)Math.Floor(timerManager.CurrentTime / 40f));
            SpawnInRandomPosition(numberEnemiesToSpawn, enemyDataToSpawn, false);
        }
    }

    private void CheckBossesToSpawn()
    {
        for (int i = 0; i < bosses.Count; i++)
        {
            if (bosses[i].IsAlreadySpawned)
                continue;

            if (bosses[i].timeToSpawn > timerManager.CurrentTime)
                continue;

            Debug.LogError("Spawn");
            BossSpawnData bossToSpawn = bosses[i];
            bossToSpawn.IsAlreadySpawned = true;
            SpawnInRandomPosition(bossToSpawn.amountToSpawn, bossToSpawn.bossToSpawn, true);
            bosses[i] = bossToSpawn;
        }

    }

    private bool IsBossPrevent()
    {
        foreach (var boss in spawnedBosses)
        {
            return true;
        }
        return false;
    }

    private bool CheckSpawn()
    {
        timeFromLastSpawn += Time.deltaTime;

        if (timeFromLastSpawn > timeBetweenSpawns)
        {
            timeFromLastSpawn = 0f;
            return true;
        }
        return false;
    }

    private void SpawnInRandomPosition(int numberEnemiesToSpawn, EnemyData enemyDataToSpawn, bool isBoss)
    {

        for (int i = 0; i < numberEnemiesToSpawn; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0);
            position.Normalize();
            position *= distanceFromCenter;
            Enemy spawnedEnemy = SpawnInPlace(enemyDataToSpawn, position);
            spawnedEnemies.Add(spawnedEnemy);
            if (isBoss)
            {
                spawnedBosses.Add(spawnedEnemy);
            }
        }
    }

    public void Spawn(EnemyData enemyData, Vector3 position)
    {
        spawnedEnemies.Add(SpawnInPlace(enemyData, position));
    }

    private void OnEnemyDespawn(Enemy obj)
    {
        spawnedEnemies.Remove(obj);
        if (spawnedBosses.Contains(obj))
        {
            spawnedBosses.Remove(obj);
        }
    }

    private Enemy SpawnInPlace(EnemyData enemy, Vector3 position)
    {
        var newEnemy = Instantiate(enemy.enemyPrefab, position, Quaternion.identity).GetComponent<Enemy>();
        newEnemy.SetStats(enemy.health * GetMultipier(), enemy.speed, enemy.movementType, enemy.experienceMultiplayer);
        float distance = float.MaxValue;
        Base targetBase = null;
        foreach (var singleBase in gameplayManager.AllBases)
        {
            float newDistance = Vector3.Distance(position, singleBase.transform.position);
            if (newDistance < distance)
            {
                targetBase = singleBase;
                distance = newDistance;
            }
        }
        newEnemy.SetTarget(targetBase.transform.position);
        return newEnemy;
    }

    private float GetMultipier()
    {
        return 1f + ((timerManager.CurrentTime / 10f) * 0.01f);
    }
}

[Serializable]
public struct BossSpawnData
{
    public float timeToSpawn;
    public EnemyData bossToSpawn;
    public int amountToSpawn;
    public bool stopSpawningBeforeDead;

    private bool isAlreadySpawned;

    public bool IsAlreadySpawned
    {
        get => isAlreadySpawned;
        set => isAlreadySpawned = value;
    }
}