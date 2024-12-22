using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public Text leaderboardText;

    void Start()
    {
        DisplayLeaderboard();
    }

    void DisplayLeaderboard()
    {
        leaderboardText.text = "";

        for (int i = 0; i < 5; i++)
        {
            string scoreKey = "Score" + i;
            string timeKey = "Time" + i;

            if (PlayerPrefs.HasKey(scoreKey))
            {
                leaderboardText.text += $"Rank {i + 1}: {PlayerPrefs.GetInt(scoreKey)} Points in {PlayerPrefs.GetFloat(timeKey):F2}s\n";
            }
        }
    }
}
