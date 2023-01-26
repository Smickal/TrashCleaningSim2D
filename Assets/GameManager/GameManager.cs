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

    [Header("Upgrade Stat")]
    [SerializeField] int speedCounter = 0;
    [SerializeField] int fuelCounter = 0;
    [SerializeField] int capacityCounter = 0;
    [SerializeField] int collectRateCounter = 0;

    int currentDayMoney;
    SaveSystem saveSystem;

    int baseDay, baseStartingMoney,baseSpeedCounter, baseFuelCounter, baseCapacityCounter, baseCollectRateCounter;
    float baseTruckSpeed, baseTruckFuel, baseTruckCollectRate;
    int baseMaxCapacity;


    private void Awake()
    {
        SaveBase();
        //TO BE ADDED
        // LOAD MONEY FROM SAVE FILE
        currentDayMoney = startingMoney;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            saveSystem = FindObjectOfType<SaveSystem>();
        }
        else
        {
            Destroy(gameObject);
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
        switch (value)
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

    public void SetTruckSpeed(float speed)
    {
        truckSpeed = speed;
    }

    public void SetTruckFuel(float fuel)
    {
        truckFuel = fuel;
    }

    public void SetTruckCapacity(int capacity)
    {
        truckMaxCapacity= capacity;
    }

    public void SetTruckCollectRate(float collectRate)
    {
        truckCollectRate= collectRate;
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


    public void SetMoneyStat(int value)
    {
        startingMoney = value;
    }

    public void SetDayStat(int value)
    {
        day = value;
    }

    public int GetSpeedUpgradeCounter()
    {
        return speedCounter;
    }

    public int GetFuelUpgradeCounter()
    {
        return fuelCounter;
    }
    
    public int GetCapacityUpgradeCounter()
    {
        return capacityCounter;
    }

    public int GetCollectRateUpgradeCounter()
    {
        return collectRateCounter;
    }

    public void SetSpeedCounter(int value)
    { speedCounter = value; }
    public void SetFuelCounter(int value) 
    { fuelCounter = value;}
    public void SetCapacityCounter(int value)
    { capacityCounter = value;}
    public void SetCollectRateCounter(int value)
    { collectRateCounter = value;}

    private void SaveBase()
    {
        baseDay = day;
        baseStartingMoney= startingMoney;

        baseSpeedCounter= speedCounter;
        baseFuelCounter= fuelCounter;
        baseCapacityCounter= capacityCounter;
        baseCollectRateCounter = collectRateCounter;

        baseTruckSpeed = truckSpeed;
        baseTruckFuel= truckFuel;
        baseMaxCapacity = truckMaxCapacity;
        baseTruckCollectRate = truckCollectRate;
    }

    public void LoadBase()
    {
        day = baseDay;
        startingMoney = baseStartingMoney;

        speedCounter = 0;
        fuelCounter = 0;
        capacityCounter = 0;
        collectRateCounter = 0;

        truckSpeed = baseTruckSpeed;
        truckFuel = baseTruckFuel;
        truckMaxCapacity = baseMaxCapacity;
        truckCollectRate = baseTruckCollectRate;
    }
}
