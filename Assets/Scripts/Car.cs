using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Scripting.APIUpdating;


public class Car : MonoBehaviour
{
    CharacterController characterController;
    GameObject camera;

    private Vector3 moveDirection;
    
    [SerializeField] public float topSpeed = 20;
    public float dragSpeed = 5;

    private float speed = 1.0f;
    private float gravityValue = -9.81f;
    float gravity_velocity = 0;

    private float gear = 1;


    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = gameObject.transform.GetChild(0).gameObject;
        //vehicleSpeed = gam
    }

    // Update is called once per frame
    void Update()
    {   
        ApplyCharacterGravity();
        moveDirection.Normalize();
        characterController.Move(moveDirection * AccelerateVehicle() * Time.deltaTime);
        //MaintainSpeed();
    }

    public void AddMoveInput(float forwardInput, float rightInput) {
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        moveDirection += (forwardInput * forward) + (rightInput * right);

    }

    public void changeCameraDirection(float rightInput) { 
        gameObject.transform.Rotate(0,rightInput,0);
        camera.transform.rotation.SetLookRotation(gameObject.transform.forward);
    }

    private void ApplyCharacterGravity() { 
        if(!characterController.isGrounded)
        {
            gravity_velocity += gravityValue * Time.deltaTime;
            Vector3 velocityVector = new Vector3(0.0f,gravity_velocity, 0.0f);
            characterController.Move(velocityVector);
        }
    }

    public float AccelerateVehicle() {
        speed += (float)((-topSpeed /Math.Pow(2, speed/10)) + topSpeed) * Time.deltaTime;
        return speed;
    }

    public void MaintainSpeed(){ 
         Vector3 direction;
         Quaternion lookDirection = camera.transform.rotation;
         float direction_x = lookDirection.x;
         float direction_z = lookDirection.z;
         direction = new Vector3(direction_x, 0, direction_z);
         direction.Normalize();

         speed *= 0.95f;


        characterController.Move(direction * speed);
    }

}
