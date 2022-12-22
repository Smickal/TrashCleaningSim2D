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
    [SerializeField] bool isLevel3Unlocked = false;
    [SerializeField] int level3Price = 3000;



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

    private void Start()
    {


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
}
