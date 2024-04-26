using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CollectibleBehaviour : MonoBehaviour
{
  private float speed; 
  [SerializeField] float speedIncrease = 70;
  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log ("The player character has touched the powerup.");
        }
        speed = other.gameObject.GetComponent<Car>().topSpeed;
        SpeedBoost();
        
    }

    IEnumerator SpeedBoost()
    {
        float oldSpeed = speed;
        speed+=speedIncrease;
        yield return new WaitForSeconds(2.0f);
        speed = oldSpeed;
    }
}

