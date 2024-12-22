using UnityEngine;

public class RandomCoinGenration : MonoBehaviour
{
    public GameObject coin;
    public Vector3 spawnAreaCenter;
    public Vector3 spawnAreaSize;
    public int numberOfCoins = 10;
    public float spawnInterval = 2f;

    private float timer = 0f;

    void Start()
    {
        SpawnCoins();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnCoin();
            timer = 0f;
        }
    }

    void SpawnCoin()
    {
        Vector3 randomPosition = GetRandomPosition();
        Instantiate(coin, randomPosition, Quaternion.identity);
    }

    void SpawnCoins()
    {
        for(int i = 0; i < numberOfCoins; i++)
        {
            SpawnCoin();
        }
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float randomY = Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2);
        float randomZ = Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);

        return new Vector3(randomX, randomY, randomZ);
    }

    public void RespawnCoins()
    {
        foreach(GameObject coin in GameObject.FindGameObjectsWithTag("coin"))
        {
            Destroy(coin);
        }
        
        SpawnCoins();
    }
}
