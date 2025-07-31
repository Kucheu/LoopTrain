using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameState CurrentGameState => currentGameState;

    private GameState currentGameState = GameState.Menu;

    public void ChangeGameState(GameState newGameState)
    {
        Debug.Log($"Changing gamestate from {CurrentGameState} to {newGameState}");
        currentGameState = newGameState;
    }

    public void StartGame()
    {
        ChangeGameState(GameState.Playing);
    }
}
