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
                Vector3 direction = enemy.TargetPosition - enemy.transform.position;
                direction.Normalize();
                enemy.transform.position = enemy.transform.position + (direction * (enemy.Speed) * Time.deltaTime);
            }
        }
    }
}
