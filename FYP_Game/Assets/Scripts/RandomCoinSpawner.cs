using UnityEngine;

public class RandomCoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Assign your coin prefab in the Inspector
    public Transform[] waypoints; // Drag and drop waypoints here

    private int currentWaypointIndex = 0;

    void Start()
    {
        // Spawn the first coin at the first waypoint
        SpawnCoinAtWaypoint(currentWaypointIndex);
    }

    public void OnCoinCollected()
    {
        // Hide the current coin and spawn the next one
        currentWaypointIndex++;

        if (currentWaypointIndex < waypoints.Length)
        {
            SpawnCoinAtWaypoint(currentWaypointIndex);
        }
    }

    void SpawnCoinAtWaypoint(int index)
    {
        if (index < waypoints.Length)
        {
            // Instantiate the coin at the waypoint position
            Instantiate(coinPrefab, waypoints[index].position, Quaternion.identity);
        }
    }
}
