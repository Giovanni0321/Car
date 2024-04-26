using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceActivator : MonoBehaviour
{
    public float timer = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1; 
            timer = 0.0f;
            timer += Time.deltaTime;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player" && timer == 10.0f)
        {
            Time.timeScale = 0;
            print("Game paused");
        }
    }

    public bool isPaused()
    {   
        if(Time.timeScale == 0)
        {
            return true; 
        }

        return false;

    }
}
