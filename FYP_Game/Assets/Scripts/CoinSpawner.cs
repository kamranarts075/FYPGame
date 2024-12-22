using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Waypoints Settings")]
    public Transform[] spawnPoints;
    public GameObject coinPrefab;
    private GameObject[] spawnedCoins;

    private int currentIndex = 0;

    void Start()
    {
        spawnedCoins = new GameObject[spawnPoints.Length];

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject coin = Instantiate(coinPrefab, spawnPoints[i].position, Quaternion.identity);

            coin.SetActive(false);

            spawnedCoins[i] = coin;
        }

        if (spawnedCoins.Length > 0)
        {
            spawnedCoins[0].SetActive(true);
        }
    }

    public void CoinCollected()
    {
        if (currentIndex < spawnedCoins.Length)
        {
            spawnedCoins[currentIndex].SetActive(false);

            currentIndex++;

            if (currentIndex < spawnedCoins.Length)
            {
                spawnedCoins[currentIndex].SetActive(true);
            }
        }
    }
}
