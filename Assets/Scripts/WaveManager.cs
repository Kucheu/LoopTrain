using System;
using System.Collections.Generic;
using UnityEngine;


public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private List<EnemyData> enemies;
    [SerializeField]
    private float timeBetweenSpawns;
    [SerializeField]
    private float distanceFromCenter;
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private List<Base> bases;

    public List<Enemy> SpawnedEnemies => spawnedEnemies;

    private float timeFromLastSpawn;
    private List<Enemy> spawnedEnemies;

    private void Awake()
    {
        spawnedEnemies = new();
    }

    private void OnEnable()
    {
        Enemy.Death += OnEnemyDeath;
    }

    private void OnDisable()
    {
        Enemy.Death -= OnEnemyDeath;
    }

    private void Update()
    {
        if (gameplayManager.CurrentGameState == GameState.Playing && CheckSpawn())
        {
            Spawn();
        }
    }

    private bool CheckSpawn()
    {
        timeFromLastSpawn += Time.deltaTime;

        if(timeFromLastSpawn > timeBetweenSpawns)
        {
            timeFromLastSpawn = 0f;
            return true;
        }
        return false;
    }

    private void Spawn()
    {
        var enemyDataToSpawn = enemies[UnityEngine.Random.Range(0, enemies.Count)];
        int numberEnemiesToSpawn = UnityEngine.Random.Range(0, 5);
        for(int i = 0; i < numberEnemiesToSpawn; i++)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0);
            position.Normalize();
            position *= distanceFromCenter;
            spawnedEnemies.Add(SpawnInPlace(enemyDataToSpawn, position));
        }
    }

    public void Spawn(EnemyData enemyData, Vector3 position)
    {
        spawnedEnemies.Add(SpawnInPlace(enemyData, position));
    }

    private void OnEnemyDeath(Enemy obj)
    {
        spawnedEnemies.Remove(obj);
    }

    private Enemy SpawnInPlace(EnemyData enemy, Vector3 position)
    {
        var newEnemy = Instantiate(enemy.enemyPrefab, position, Quaternion.identity).GetComponent<Enemy>();
        newEnemy.SetStats(enemy.health, enemy.speed);
        float distance = float.MaxValue;
        Base targetBase = null;
        foreach(var singleBase in bases)
        {
            float newDistance = Vector3.Distance(position, singleBase.transform.position);
            if (newDistance < distance)
            {
                targetBase = singleBase;
                distance = newDistance;
            }
        }
        newEnemy.SetTarget(targetBase);
        return newEnemy;
    }
}