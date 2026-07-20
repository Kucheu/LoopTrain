using System.Threading.Tasks;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private void Awake()
    {
        Debug.LogError(Application.persistentDataPath);
    }

    /*
    public Task<bool> Load()
    {
        int x = 1;
        return x != 1;
    }

    public Task<bool> Save()
    {
        return false;
    }
    */
}
