using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Kucheu/EnemySystem/EnemyData")]
public class EnemyData : ScriptableObject
{
    public GameObject enemyPrefab;
    public float health;
    public float speed;
}
