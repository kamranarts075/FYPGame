using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter(Collider colliderCoin)
    {
        //Debug.LogError("On trigger error");

        if(colliderCoin.CompareTag("Player"))
        {
            //Debug.Log("Coin Collected by player");

            GameManager.Instance.AddCoins();

            Destroy(gameObject);
        }
    }
}
