using UnityEngine;
using System;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Car : MonoBehaviour
{
    Rigidbody rigidbody;
    GameObject camera;
    MeshCollider collider;
    
    float speed;
    [SerializeField] public float topSpeed = 70.0f;
    [SerializeField] float acceleration_rate = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<MeshCollider>();
        collider.convex = true;
        camera = gameObject.transform.GetChild(0).gameObject;
        speed = rigidbody.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        print("Car Rigidbody speed: " + speed);
        // ApplyDownwardForce();
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

    public void ApplyDownwardForce() {
        //rigidbody.AddForce(Vector3.down * 3);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.name != "player") {
            print("temp");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.name == "Wall") {
            Vector3 oldVelocity = rigidbody.velocity;
            Vector3 newVelocity = oldVelocity * -1;

            rigidbody.AddForce(newVelocity);
        }

    }
}
