using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private SceneReference menuScene;

    private bool isPaused;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !startMenu.activeSelf && gameplayManager.CurrentGameState != GameState.Building)
        {
            ChangeMenuActive();
        }
    }

    public void ChangeMenuActive()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        gameplayManager.ChangeGameState(isPaused ? GameState.Menu : GameState.Playing);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(menuScene.BuildIndex);
    }
}
