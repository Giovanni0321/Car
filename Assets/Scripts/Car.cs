using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Car : MonoBehaviour
{
    CharacterController characterController;
    GameObject camera;

    private Vector3 moveDirection;
    
    public float speed = 1.0f;
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
        characterController.Move(moveDirection * useAcclerationCurve() * Time.deltaTime);
    }

    public void AddMoveInput(float forwardInput, float rightInput) {
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        moveDirection = (forwardInput * forward) + (rightInput * right);
    }

    public void changeCameraDirection(float rightInput) { 
        gameObject.transform.Rotate(0,rightInput,0);
        camera.transform.rotation.SetLookRotation(gameObject.transform.forward);
    }

    private void ApplyCharacterGravity() {
        print(characterController.isGrounded);
        
 
        if(!characterController.isGrounded)
        {
            
            gravity_velocity += gravityValue * Time.deltaTime;
            print(gravity_velocity);
            Vector3 velocityVector = new Vector3(0.0f,gravity_velocity, 0.0f);
            characterController.Move(velocityVector);
        }
    }

    public float useAcclerationCurve() {

        speed += ((float)((double)-70 / (double)Math.Pow(2, (double)speed/(double)10)) + (float)70) * Time.deltaTime;
        return speed;
    }


}
