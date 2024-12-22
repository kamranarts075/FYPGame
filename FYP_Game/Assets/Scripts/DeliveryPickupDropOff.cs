using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPickupDropOff : MonoBehaviour
{
    public MissionController missionController;

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject == missionController.pickupPoint && !missionController.hasPickedUpItems && Input.GetKeyDown(KeyCode.E))
        {
            missionController.PickupAllItems();
            Debug.Log("Picked All Items");
        }

        if(missionController.hasPickedUpItems && collider.gameObject == missionController.deliveryPoints[missionController.currentDeliveryIndex] && Input.GetKeyDown(KeyCode.E))
        {
            missionController.CompleteDelivery();
            Debug.Log("Completed a Delivery");
        }
    }

    //public GameObject pickupPizza;
    //public GameObject seatPizza;
    //public GameObject dropOffPoint;

    //private bool isNearPickup = false;
    //private bool isNearDropOff = false;
    //private bool hasPizza = false;

    //void Start()
    //{
    //    seatPizza.SetActive(false);
    //}

    //void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.E))
    //    {
    //        if(isNearPickup && !hasPizza)
    //        {
    //            PickUpPizza();
    //        }
    //        else if(isNearDropOff && hasPizza)
    //        {
    //            DropOffPizza();
    //        }
    //    }
    //}

    //void PickUpPizza()
    //{
    //    // Picking pizza box
    //    hasPizza = true;

    //    // Destroy the pizza box at pickup
    //    Destroy(pickupPizza);

    //    // Active the hidden pizza box
    //    seatPizza.SetActive(true);
    //    Debug.Log("Pizza Pickedup!");
    //}

    //void DropOffPizza()
    //{
    //    // Pizza box drop off
    //    hasPizza = false;

    //    // Hide the pizza box on seat
    //    seatPizza.SetActive(false);
    //    Debug.Log("Pizza Delivered!");
    //}

    //private void OnTriggerEnter(Collider colliderPizza)
    //{
    //    if(colliderPizza.gameObject == pickupPizza)
    //    {
    //        isNearPickup = true;
    //    }
    //    else if(colliderPizza.gameObject == dropOffPoint && hasPizza)
    //    {
    //        isNearDropOff = true;
    //    }
    //}

    //private void OnTriggerExit(Collider colliderPizza)
    //{
    //    if(colliderPizza.gameObject == pickupPizza)
    //    {
    //        isNearPickup = false;
    //    }
    //    else if(colliderPizza.gameObject == dropOffPoint)
    //    {
    //        isNearDropOff = false;
    //    }
    //}
}
