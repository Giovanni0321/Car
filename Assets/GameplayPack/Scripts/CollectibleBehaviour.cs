using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
 [Serializable]

public class CollectibleBehaviour : MonoBehaviour
{
  UnityEvent collect = new UnityEvent();
  private float speed; 
  [SerializeField] float speedIncrease = 70;
  void Start()
  {
    collect.AddListener(visualEffect);
  }
  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log ("The player character has touched the powerup.");
            speed = other.gameObject.GetComponent<Car>().topSpeed;
            SpeedBoost();
            collect.Invoke();


        }
        
        
    }

    IEnumerator SpeedBoost()
    {
        float oldSpeed = speed;
        speed+=speedIncrease;
        yield return new WaitForSeconds(2.0f);
        speed = oldSpeed;
    }

    void visualEffect()
    {
        ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem.Play();

        gameObject.SetActive(false);
    }
}

