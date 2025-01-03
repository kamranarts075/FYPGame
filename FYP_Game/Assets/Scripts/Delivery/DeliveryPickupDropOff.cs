using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryPickupDropOff : MonoBehaviour
{
    [Header("Pickup and Delivery Points")]
    public Transform pickupPoint;
    public Transform[] deliveryPoints;

    [Header("Interaction Settings")]
    public KeyCode interactKey = KeyCode.E;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    [Header("Scoring and Timer")]
    public int pointsPerDelivery = 10;
    public float deliveryTimeLimit = 60f;

    public GameObject loseScreen;
    public GameObject winScreen;

    private int score = 0;
    private float timer;
    private bool isTimerActive = false;

    private int currentDeliveryIndex = -1;
    private Transform currentTarget;

    void Start()
    {
        UpdateScoreUI();

        foreach (var point in deliveryPoints)
        {
            point.gameObject.SetActive(false);
        }

        currentTarget = pickupPoint;
    }

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            HandleInteraction();
        }

        if (isTimerActive)
        {
            UpdateTimer();
        }
    }

    void HandleInteraction()
    {
        if (currentTarget == pickupPoint)
        {
            Debug.Log("Pickup Accepted!");

            pickupPoint.gameObject.SetActive(false);

            currentDeliveryIndex = 0;
            currentTarget = deliveryPoints[currentDeliveryIndex];
            deliveryPoints[currentDeliveryIndex].gameObject.SetActive(true);

            StartTimer();
        }
        else if (currentTarget == deliveryPoints[currentDeliveryIndex])
        {
            Debug.Log($"Delivery {currentDeliveryIndex + 1} Completed!");

            deliveryPoints[currentDeliveryIndex].gameObject.SetActive(false);

            currentDeliveryIndex++;
            if (currentDeliveryIndex < deliveryPoints.Length)
            {
                currentTarget = deliveryPoints[currentDeliveryIndex];
                deliveryPoints[currentDeliveryIndex].gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("All Deliveries Completed!");
                ShowWinScreen();
            }

            score += pointsPerDelivery;
            UpdateScoreUI();


            if (currentDeliveryIndex >= deliveryPoints.Length)
            {
                isTimerActive = false;
            }
        }
    }

    void ShowWinScreen()
    {
        Time.timeScale = 0; // Freeze the game
        winScreen.SetActive(true); // Show Win Screen
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Delivery Score: " + score;
    }

    void StartTimer()
    {
        timer = deliveryTimeLimit;
        isTimerActive = true;
    }

    void UpdateTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = " : " + Mathf.Ceil(timer);
        }
        else
        {
            isTimerActive = false;
            Debug.Log("Time's up! Delivery failed.");
            timerText.text = "00:00";

            deliveryPoints[currentDeliveryIndex].gameObject.SetActive(false);
            currentDeliveryIndex++;

            ShowLoseScreen();
        }
    }

    void ShowLoseScreen()
    {
        Time.timeScale = 0; // Freeze the game
        loseScreen.SetActive(true); // Show Lose Screen
    }
}
