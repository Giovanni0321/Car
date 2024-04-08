using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    CharacterController characterController;
    GameObject camera;

    private Vector3 moveDirection;
    
    public float moveSpeed = 5.0f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {    
        moveDirection.Normalize();
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
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
}
