using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RaceActivator : MonoBehaviour
{
    public float timer = 10;

    void Update()
    {
        if (timer == 0) //Temporary so code error in code doesn't show
        {
            Time.timeScale = 1; 
            timer = 0.0f;
        }

        timer += Time.deltaTime;
    }

    public void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player" && timer >= 10.0f)
        {
            Time.timeScale = 0;
            print("Game paused");
            SceneManager.LoadScene("RaceDecider", LoadSceneMode.Additive);
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
