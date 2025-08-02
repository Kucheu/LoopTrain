using System;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public event Action GameEnded;

    public GameState CurrentGameState => currentGameState;
    public List<Base> AllBases => allBases;

    private GameState currentGameState = GameState.Menu;
    private List<Base> allBases;

    private void Awake()
    {
        allBases = new();
        allBases.AddRange(FindObjectsByType<Base>(FindObjectsSortMode.None));
    }

    public void ChangeGameState(GameState newGameState)
    {
        Debug.Log($"Changing gamestate from {CurrentGameState} to {newGameState}");
        currentGameState = newGameState;
    }

    public void StartGame()
    {
        ChangeGameState(GameState.Playing);
    }

    public void RemoveBase(Base oldBase)
    {
        allBases.Remove(oldBase);
        if(allBases.Count == 0)
        {
            ChangeGameState(GameState.EndGame);
            GameEnded?.Invoke();
        }
    }
}
