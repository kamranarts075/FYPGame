using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text coinScoreText;
    public Text deliveriesLeftText;

    private int coinScore = 0;
    private int deliveriesLeft = 5;

    void UpdateHUD()
    {
        coinScoreText.text = "Coins: " + coinScore;
        deliveriesLeftText.text = "Deliveries Left: " + deliveriesLeft;
    }

    public void AddCoin()
    {
        coinScore++;
        UpdateHUD();
    }

    public void CompleteDelivery()
    {
        deliveriesLeft--;
        UpdateHUD();
    }
}
