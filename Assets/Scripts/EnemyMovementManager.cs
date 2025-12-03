using System;
using UnityEngine;

public class EnemyMovementManager : MonoBehaviour
{
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private WaveManager waveManager;

    private void Update()
    {
        if(gameplayManager.CurrentGameState == GameState.Playing)
        {
            foreach(var enemy in waveManager.SpawnedEnemies)
            {
                switch(enemy.MovementType)
                {
                    case MovementType.Normal:
                        NormalMovement(enemy);
                        break;
                    case MovementType.JumpingAround:
                        JumpMovement(enemy);
                        break;
                }
                
            }
        }
    }

    private void NormalMovement(Enemy enemy)
    {
        Vector3 direction = enemy.TargetPosition - enemy.transform.position;
        direction.Normalize();
        enemy.transform.position = enemy.transform.position + (direction * (enemy.Speed) * Time.deltaTime);
    }

    private void JumpMovement(Enemy enemy)
    {
        if(enemy.TimeFromLastMovement >= enemy.Speed)
        {
            Vector3 position = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0);
            position.Normalize();
            position *= 10f;
            enemy.SetTarget(position);
            enemy.transform.position = enemy.TargetPosition;
            enemy.TimeFromLastMovement = 0f;
        }
        else
        {
            enemy.TimeFromLastMovement += Time.deltaTime;
        }
    }
}
