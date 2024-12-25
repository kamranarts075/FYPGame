using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Splines;

public class CoinSpline : MonoBehaviour
{
    [Header("Spline Reference")]
    public SplineContainer splineContainer;
    public GameObject coinPrefab;

    [Header("Spawn Settings")]
    public int numberOfCoins = 5;
    private List<GameObject> coins = new List<GameObject>();
    private int currentCoinIndex = 0;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        SpawnCoinsAlongSpline();
        ActivateCoin(0);
        UpdateScoreUI();
    }

    void SpawnCoinsAlongSpline()
    {
        float segmentStep = 1f / numberOfCoins;

        for (int i = 0; i < numberOfCoins; i++)
        {
            float startT = i * segmentStep;
            float endT = (i + 1) * segmentStep;

            float randomT = Random.Range(startT, endT);

            Vector3 position = splineContainer.EvaluatePosition(randomT);

            GameObject coin = Instantiate(coinPrefab, position, Quaternion.identity);
            coin.SetActive(false);

            coins.Add(coin);
        }
    }

    void ActivateCoin(int index)
    {
        if (index < coins.Count)
        {
            coins[index].SetActive(true);
        }
    }

    public void CollectCoin()
    {
        if (currentCoinIndex < coins.Count)
        {
            Destroy(coins[currentCoinIndex]);
            currentCoinIndex++;
            ActivateCoin(currentCoinIndex);

            score += 10;
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
        Debug.Log("Coin Collected by player");
    }
}
