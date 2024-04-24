using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CarSelect : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] public GameObject[] cars; 
    int current = 0;
    void Start()
    {
       //Next();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        print("Previous Car Index:"+current);
        print("Previous Car:"+cars[current].name);
        cars[current].SetActive(false);
        current--;
        if (current >= 0)
            cars[current].SetActive(true);
        else 
            current = cars.Length-1;
            cars[current].SetActive(true);
        print("Car After Clicking Back:"+cars[current].name);
        print("Current Car Index:"+current);


    }
    public void Next()
    {   print("Previous Car Index:"+current);

        print("Previous Car:"+cars[current].name);
        cars[current].SetActive(false);
        current++;
        if (current < cars.Length)
            cars[current].SetActive(true);
        else 
            current = 0;
            cars[current].SetActive(true);
             
        print("Car After Clicking Next:"+cars[current].name);
        print("Current Car Index:"+current);

    }

    public void SelectedCar()
    {
        PlayerPrefs.SetInt("selectedCar",current);
        //PlayerPrefs.GetInt(selectedCar);
    }
}
