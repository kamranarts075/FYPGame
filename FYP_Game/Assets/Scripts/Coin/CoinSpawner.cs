using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Coin Prefab")]
    public GameObject[] coinPrefab;

    private int currentIndex = 0;

    void Start()
    {
        for(int i = 0; i < coinPrefab.Length; i++)
        {
            coinPrefab[i].SetActive(i == 0);
        }
    }

    public void CollectCoin()
    {
        if(currentIndex < coinPrefab.Length)
        {
            coinPrefab[currentIndex].SetActive(false);
            currentIndex++;

            if(currentIndex < coinPrefab.Length)
            {
                coinPrefab[currentIndex].SetActive(true);
            }
        }
    }
}
