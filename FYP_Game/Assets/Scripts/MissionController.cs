using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    public GameObject pickupPoint;
    public GameObject[] deliveryPoints;
    public int currentDeliveryIndex = 0;
    public bool hasPickedUpItems = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject point in deliveryPoints)
        {
            point.SetActive(false);
        }

        pickupPoint.SetActive(true);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(!hasPickedUpItems && Vector3.Distance(transform.position, pickupPoint.transform.position) < 3f && Input.GetKeyDown(KeyCode.E))
    //    {
    //        PickupAllItems();
    //    }
    //}

    public void PickupAllItems()
    {
        if(!hasPickedUpItems)
        {
            hasPickedUpItems = true;
            pickupPoint.SetActive(false);
            deliveryPoints[currentDeliveryIndex].SetActive(true);
        }
    }

    public void CompleteDelivery()
    {
        deliveryPoints[currentDeliveryIndex].SetActive(false);

        currentDeliveryIndex++;

        if(currentDeliveryIndex < deliveryPoints.Length)
        {
            deliveryPoints[currentDeliveryIndex].SetActive(true);
        }
        else
        {
            //Debug.Log("All Deliveries Completed! Loading Next Scene");
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load. Game Completed!");
        }
    }
}
