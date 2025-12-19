using UnityEngine;
using TMPro;

public class KillCounterUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI killText;

    private int currentCount = 0;

    private void OnEnable()
    {
        killText.text = currentCount.ToString();
        Enemy.Death += OnEnemyKill;
    }

    private void OnDisable()
    {
        Enemy.Death -= OnEnemyKill;
    }

    private void OnEnemyKill(Enemy _)
    {
        currentCount += 1;
        killText.text = currentCount.ToString();
    }
}
