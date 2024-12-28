using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider progressBar; // Reference to the Slider UI
    public TextMeshProUGUI progressText; // Reference to the progress text

    void Start()
    {
        string nextScene = PlayerPrefs.GetString("Level1", "Level2");
        LoadScene(nextScene);
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.value = progress;
            progressText.text = $"Loading... {Mathf.RoundToInt(progress * 100)}%";

            //if (operation.progress >= 0.9f)
            //{
            //    progressText.text = "Press any key to continue...";
            //    if (Input.anyKeyDown)
            //    {
            //        operation.allowSceneActivation = true;
            //    }
            //}

            yield return null;
        }
    }
}
