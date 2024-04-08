using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float timer;
    private bool end;
    //public static class Math;
    public Text timerDisplay;
    public bool End
    {
        get{return end;}
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 30;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timerDisplay.text = ("Timer: 0");
                end = true;
            }
            else
            {
                timerDisplay.text = ("Timer: "+Math.Round(timer));
            }
        }
    }
}
