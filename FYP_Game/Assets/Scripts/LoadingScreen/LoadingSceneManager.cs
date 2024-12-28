using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public void TriggerLoadingScreen(string sceneName)
    {
        SceneManager.LoadScene("LoadingScreen");
        PlayerPrefs.SetString("Level1", sceneName);
    }
}
