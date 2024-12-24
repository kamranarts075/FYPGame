using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public int coinValue = 1;

    public CoinSpawner coinSpawner;

    void Start()
    {
        coinSpawner = FindAnyObjectByType<CoinSpawner>();

        if(coinSpawner == null)
        {
            //Debug.LogError("CoinController not found in the scene. Please add it.");
        }
    }

    void OnTriggerEnter(Collider colliderCoin)
    {
        //Debug.LogError("On trigger error");

        if(colliderCoin.CompareTag("Player"))
        {
            //Debug.Log("Coin Collected by player");
            coinSpawner.CollectCoin();

            //GameManager.Instance.AddCoins();

            Destroy(gameObject);
        }
    }
}
