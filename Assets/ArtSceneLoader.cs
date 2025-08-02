using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtSceneLoader : MonoBehaviour
{
    [SerializeField]
    private SceneReference artScene;

    private void OnEnable()
    {
        SceneManager.LoadSceneAsync(artScene.BuildIndex, LoadSceneMode.Additive);
    }
}
