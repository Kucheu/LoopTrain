using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Kucheu/EnemySystem/EnemyData")]
public class EnemyData : ScriptableObject
{
    public GameObject enemyPrefab;
    public float health;
    [Tooltip("Movement speed, time to next jump")]
    public float speed;
    public float experienceMultiplayer = 1f;
    public MovementType movementType;
}
