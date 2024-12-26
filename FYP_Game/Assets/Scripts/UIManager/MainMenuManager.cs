using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel, settingPanel, levelSelectionPanel, shopPanel, coinPanel, leaderboardPanel;

    public void Start()
    {
        HideAllPanels();
        mainMenuPanel.SetActive(true);
    }

    //public void ShowMainMenu()
    //{
    //    HideAllPanels();
    //    mainMenuPanel.SetActive(true);
    //}

    public void ShowLevelSelection(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex);
    }

    public void ShowSetting()
    {
        HideAllPanels();
        settingPanel.SetActive(true);
    }

    public void ShowShop()
    {
        HideAllPanels();
        shopPanel.SetActive(true);
    }

    public void ShowCoin()
    {
        HideAllPanels();
        coinPanel.SetActive(true);
    }

    public void ShowLeaderboard()
    {
        HideAllPanels();
        leaderboardPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void HideAllPanels()
    {
        mainMenuPanel.SetActive(false);
        settingPanel.SetActive(false);
        levelSelectionPanel.SetActive(false);
        shopPanel.SetActive(false);
        coinPanel.SetActive(false);
        leaderboardPanel.SetActive(false);
    }
}
