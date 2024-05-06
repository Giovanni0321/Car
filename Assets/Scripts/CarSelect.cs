using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class CarSelect : MonoBehaviour
{
      
    [SerializeField] public GameObject[] cars; 
    int current = 0;

    // Start is called before the first frame update
    void Start()
    {
       //Next();
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

    public void putCarInScene() {
         print("Previous Car:"+cars[current].name);
         Instantiate(cars[current], GameObject.Find("GameObject").transform);
    }

}
