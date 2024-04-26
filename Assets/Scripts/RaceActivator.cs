using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceActivator : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1; 
        }
    }

    public void OnEnter()
    {
        if (gameObject.tag == "Player")
        {
            Time.timeScale = 0;
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
