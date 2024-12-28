using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SplashScreenManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject pressAnyKeyText;
    public float splashDuration = 2f;
    private bool isKeyPressAllowed = false;

    void Start()
    {
        pressAnyKeyText.SetActive(false);

        StartCoroutine(ShowPressAnyKeyText());
    }

    void Update()
    {
        if (isKeyPressAllowed && Input.anyKeyDown)
        {
            LoadNextScene();
        }
    }

    private IEnumerator ShowPressAnyKeyText()
    {
        yield return new WaitForSeconds(splashDuration);

        pressAnyKeyText.SetActive(true);
        isKeyPressAllowed = true;
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("GameUI");
    }
}
