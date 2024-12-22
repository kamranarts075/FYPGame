using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BikeController : MonoBehaviour
{
    public float motorSpeed = 10f;
    public float turnSpeed = 5f;
    public float tiltAngle = 30f;
    public float rotateSmooth = 5f;

    public Transform frontWheel;
    public Transform backWheel;
    public Transform handleBar;

    private Rigidbody rb;
    private float inputVertical;
    private float inputHorizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

        rb.centerOfMass = new Vector3(0f, 0.5f, 0f);
    }

    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");

        MoveBike();

        RotateWheels();

        RotateHandleBars();
    }

    void MoveBike()
    {
        // Bike forward movement
        Vector3 forwardMovement = transform.forward * inputVertical * motorSpeed;
        //rb.MovePosition(rb.position + forwardMovement);
        rb.linearVelocity = new Vector3(forwardMovement.x, rb.linearVelocity.y, forwardMovement.z);

        // Bike turning
        if (inputHorizontal != 0)
        {
            Quaternion turnRotation = Quaternion.Euler(0f, inputHorizontal * turnSpeed, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        //float turnBike = inputHorizontal * turnSpeed;
        //Quaternion turnRotation = Quaternion.Euler(0, turnBike, 0);
        //rb.MoveRotation(rb.rotation * turnRotation);

        // Bike tilt on turn
        float tiltBike = inputHorizontal * tiltAngle;
        Quaternion targetRotation = Quaternion.Euler(0f, rb.rotation.eulerAngles.y, -tiltBike);
        rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotateSmooth * Time.deltaTime);
    }

    void RotateWheels()
    {
        // Rotate the wheels
        float rotationAmount = inputVertical * motorSpeed * 360f;
        frontWheel.Rotate(Vector3.right, rotationAmount);
        backWheel.Rotate(Vector3.right, rotationAmount);
    }

    void RotateHandleBars()
    {
        // Bike handlebar rotation
        float handlebarTurn = inputHorizontal * 30f;

        Vector3 fixedRotation = handleBar.localRotation.eulerAngles;

        fixedRotation.x = 0f;
        fixedRotation.y = handlebarTurn;
        fixedRotation.z = 0f;

        handleBar.localRotation = Quaternion.Euler(fixedRotation);

        FrontWheelRotation(handlebarTurn);

        //Quaternion targetHandlebarRotation = Quaternion.Euler(0f, handlebarTurn, 0f);
        //handleBar.localRotation = Quaternion.Slerp(handleBar.localRotation, targetHandlebarRotation, rotateSmooth * Time.deltaTime);
    }

    void FrontWheelRotation(float handlebarTurn)
    {
        Vector3 frontwheelRotation = frontWheel.localRotation.eulerAngles;

        frontwheelRotation.x = 0f;
        frontwheelRotation.y = handlebarTurn;
        frontwheelRotation.z = 0f;

        frontWheel.localRotation = Quaternion.Euler(frontwheelRotation);
    }
}
