using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Rigidbody : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject camera;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        camera = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addForce(float forwardInput) {
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        forward.Normalize();
        
        rigidbody.AddForce(forward * forwardInput, ForceMode.Acceleration);

    }

    public void changeCameraDirection(float rightInput) { 
        gameObject.transform.Rotate(0,rightInput,0);
        camera.transform.rotation.SetLookRotation(gameObject.transform.forward);
    }
}
