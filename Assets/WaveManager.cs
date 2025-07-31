using System;
using System.Collections.Generic;
using UnityEngine;


public class WaveManager : MonoBehaviour
{
    [SerializeField]
    List<EnemyData> enemies;
    [SerializeField]
    GameplayManager gameplayManager;

    private void Update()
    {
        if (gameplayManager.CurrentGameState == GameState.Playing)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        
    }
}