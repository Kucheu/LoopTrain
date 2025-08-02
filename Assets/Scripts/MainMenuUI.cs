using UnityEngine;
using Eflatun.SceneReference;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private SceneReference gameScene;
    [SerializeField]
    private GameObject mainMenuObject;
    [SerializeField]
    private GameObject settingsObject;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene.BuildIndex);
    }

    public void OpenSettings()
    {
        mainMenuObject.SetActive(false);
        settingsObject.SetActive(true);
    }

    public void OpenMainMenu()
    {
        mainMenuObject.SetActive(true);
        settingsObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
