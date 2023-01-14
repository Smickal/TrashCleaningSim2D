using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }



    // Start is called before the first frame update
    [SerializeField] int day = 1;
    [SerializeField] int startingMoney = 1000;

    [Header("Facility Cost")]
    [SerializeField] int retryCost = 5000;
    [SerializeField] int fuelCost = 200;
    [SerializeField] int repairCost = 200;

    [Header("DaySession")]
    [Tooltip("In Minute")]
    [SerializeField] float eachSessionLong = 6;

    [Header("Level Selector")]
    [SerializeField] bool isLevel1Unlocked = true;
    [SerializeField] int level1Price = 0;
    [SerializeField] bool isLevel2Unlocked = false;
    [SerializeField] int level2Price = 1500;
    [SerializeField] bool isLevel3Unlocked = true;
    [SerializeField] int level3Price = 1500;

    [Header("Truck Stat")]
    [SerializeField] float truckSpeed = 10f;
    [SerializeField] float truckFuel = 100f;
    [SerializeField] int truckMaxCapacity = 10;
    [SerializeField] float truckCollectRate = 2f;

    int currentDayMoney;



   

    private void Awake()
    {
        //TO BE ADDED
        // LOAD MONEY FROM SAVE FILE
        currentDayMoney = startingMoney;

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

    }

    public int GetRetryCost()
    {
        return retryCost;
    }



    public void SaveCurrentDayMoney(int value)
    {
        currentDayMoney = value;
    }

    public int GetCurrentDayMoney()
    {
        return currentDayMoney;
    }

    public int GetDayValue()
    {
        return day;
    }

    public void IncreaseDay()
    {
        day++;
    }

    public int GetPlayerMoney()
    {
        return startingMoney;
    }

    public int GetFuelCost()
    {
        return fuelCost;
    }

    public float GetSessionLong()
    {
        return eachSessionLong;
    }

    public int GetRepairCost()
    {
        return repairCost;
    }

    public int GetLevelCost(int value)
    {
        switch(value)
        {
            case 1:
                return level1Price;

            case 2:
                return level2Price;

            case 3:
                return level3Price;

            default:
                break;
        }

        return 0;
    }

    public void ActivateLevel(int value)
    {
        switch (value)
        {
            case 1:
                isLevel1Unlocked = true;
                break;

            case 2:
                isLevel2Unlocked = true;
                break;

            case 3:
                isLevel3Unlocked = true;
                break;

            default:
                break;
        }

    }

    public bool CheckLevel(int value)
    {
        switch (value)
        {
            case 1:
                return isLevel1Unlocked;

            case 2:
                return isLevel2Unlocked;

            case 3:
                return isLevel3Unlocked;

            default:
                break;
        }

        return false;
    }



    public void SetTruckStat(float speed, float fuel, int capacity, float collectRate)
    {
        truckSpeed = speed;
        truckFuel = fuel;
        truckMaxCapacity = capacity;
        truckCollectRate = collectRate;
    }


    public float GetTruckSpeed()
    {
        return truckSpeed;
    }
    public float GetTruckFuel() 
    { 
        return truckFuel;
    }
    public int GetTruckMaxCapacity()
    {
        return truckMaxCapacity;
    }

    public float GetTruckCollectRate()
    {
        return truckCollectRate;
    }
}
