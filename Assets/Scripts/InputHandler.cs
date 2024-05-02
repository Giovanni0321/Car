using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class InputHandler : MonoBehaviour
{
    GameObject camera;
    Car car;
    

    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.transform.GetChild(0).gameObject;
   
        car = GetComponent<Car>();
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
        car.addForce(forwardInput);
        car.changeCameraDirection(rightInput);

        
    }

    public void pauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0; 
            
        }
    }

}
