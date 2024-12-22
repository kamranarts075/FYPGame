using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenuPanel.SetActive(false);
        }
    }

    public void LoadMainMenu(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex);
    }
}
