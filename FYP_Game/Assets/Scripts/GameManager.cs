using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text coinScoreText;
    public Text deliveriesLeftText;

    private int coinScore = 0;
    private int deliveriesLeft = 5;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void UpdateHUD()
    {
        coinScoreText.text = "Coins: " + coinScore;
        deliveriesLeftText.text = "Deliveries Left: " + deliveriesLeft;
    }

    public void AddCoins()
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
