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
    public static GameObject global_car;

    // Start is called before the first frame update
    void Start()
    {
        global_car = (GameObject)Resources.Load("Car", typeof(GameObject));
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

        SetCar(cars[current].name);
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

        SetCar(cars[current].name);  
    }

    public void SelectedCar()
    {
        PlayerPrefs.SetInt("selectedCar",current);
        //PlayerPrefs.GetInt(selectedCar);
    }

    public static void PutCarInScene() {
         Instantiate(global_car, GameObject.Find("CarSpawn").transform);
    }

    public static void SetCar(string carName) {
        print("Global Car name " + carName);
        global_car = (GameObject)Resources.Load(carName, typeof(GameObject));
        print("global Car: " + global_car);
    }
}
