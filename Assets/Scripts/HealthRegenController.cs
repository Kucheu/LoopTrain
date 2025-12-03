using UnityEngine;

public class HealthRegenController : MonoBehaviour
{
    [SerializeField]
    private float baseRegenOnSecond;
    [SerializeField]
    private HealthController healthController;
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private Base baseComponent;

    private float currentTime;

    private void Update()
    {
        if(gameplayManager.CurrentGameState == GameState.Playing && !baseComponent.IsDead)
        {
            currentTime += Time.deltaTime;
        }

        if(currentTime >= 1f)
        {
            currentTime = 0f;
            healthController.Heal(baseRegenOnSecond * StatsManager.Instance.RegenHP);
        }
    }

}
