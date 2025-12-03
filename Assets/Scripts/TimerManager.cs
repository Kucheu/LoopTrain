using System;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private TMPro.TextMeshProUGUI timerUI;

    private float currentTime;

    public float CurrentTime => currentTime;

    private void Update()
    {
        if(gameplayManager.CurrentGameState == GameState.Playing)
        {
            currentTime += Time.deltaTime;
            timerUI.text = GetTimeText();
        }
    }

    private string GetTimeText()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        return string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
    }
}
