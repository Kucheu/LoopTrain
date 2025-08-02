using System;
using UnityEngine;
using TMPro;

public class DeadUI : MonoBehaviour
{
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private GameObject deadUI;
    [SerializeField]
    private TextMeshProUGUI timerText;

    private void OnEnable()
    {
        gameplayManager.GameEnded += OnGameEnded;
    }

    private void OnDisable()
    {
        gameplayManager.GameEnded -= OnGameEnded;
    }

    private void OnGameEnded()
    {
        deadUI.SetActive(true);
        timerText.text = "00:00";
    }
}
