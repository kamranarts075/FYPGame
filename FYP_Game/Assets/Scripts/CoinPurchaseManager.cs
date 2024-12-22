using UnityEngine;
using UnityEngine.UI;

public class CoinPurchaseManager : MonoBehaviour
{
    public Text coinBalanceText;
    private int coinBalance;

    private void Start()
    {
        // Load saved coin balance
        coinBalance = PlayerPrefs.GetInt("CoinBalance", 0);
        UpdateCoinBalanceUI();
    }

    public void PurchaseCoins(int amount)
    {
        // Add coins to the player's balance
        coinBalance += amount;

        // Save updated balance
        PlayerPrefs.SetInt("CoinBalance", coinBalance);
        UpdateCoinBalanceUI();

        Debug.Log("Purchased " + amount + " coins!");
    }

    private void UpdateCoinBalanceUI()
    {
        coinBalanceText.text = "Coins: " + coinBalance;
    }
}
