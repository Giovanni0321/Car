using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RB_InputHandler : MonoBehaviour
{
    GameObject camera;
    Car_Rigidbody car_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.transform.GetChild(0).gameObject;
        car_Rigidbody = GetComponent<Car_Rigidbody>();
        print(camera);
    }

    // Update is called once per frame
    void Update()
    {
        HandleMoveInput();
    }

    void HandleMoveInput() {
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");
        

        //Car rigidbody methods;
        car_Rigidbody.addForce(forwardInput);
        car_Rigidbody.changeCameraDirection(rightInput);

        
    }

}
