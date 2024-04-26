using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class Car_Rigidbody : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject camera;
    
    float speed;
    [SerializeField] float topSpeed = 70.0f;
    [SerializeField] float acceleration_rate = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        camera = gameObject.transform.GetChild(0).gameObject;
        speed = rigidbody.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        print("Car Rigidbody speed: " + speed);
        
    }

    public void addForce(float forwardInput) {
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        forward.Normalize();
        forward = forward * SpeedFormula() * forwardInput;
        
        rigidbody.AddForce(forward * Time.deltaTime, ForceMode.VelocityChange);
        rigidbody.velocity = new Vector3(forward.x, rigidbody.velocity.y, forward.z); 

    }

    public void changeCameraDirection(float rightInput) { 
        float turn_rate = rightInput/(speed * 0.5f);
        gameObject.transform.Rotate(0,turn_rate,0);
        camera.transform.rotation.SetLookRotation(gameObject.transform.forward);

    }

    public float SpeedFormula() {
        float current_speed = speed + 1;
        speed += (float)((-topSpeed /Math.Pow(2, current_speed/acceleration_rate)) + topSpeed) * Time.deltaTime;
        if (speed > topSpeed) {
            speed = topSpeed;
        }

        return current_speed;
    }
}
