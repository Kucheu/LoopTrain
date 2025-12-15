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
    [SerializeField]
    private GameObject upgradeObject;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene.BuildIndex);
    }

    public void OpenSettings()
    {
        mainMenuObject.SetActive(false);
        settingsObject.SetActive(true);
        upgradeObject.SetActive(false);
    }

    public void OpenMainMenu()
    {
        mainMenuObject.SetActive(true);
        settingsObject.SetActive(false);
        upgradeObject.SetActive(false);
    }

    public void OpenUpgradeMenu()
    {
        mainMenuObject.SetActive(false);
        settingsObject.SetActive(false);
        upgradeObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
