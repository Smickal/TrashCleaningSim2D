using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    // Start is called before the first frame update

    GameManager gameManager;


    [SerializeField] MoneyCounter moneyCounter;
    [SerializeField] DayCounter dayCounter;
    [SerializeField] DisplayTruckStat displayTruckStat;
    [SerializeField] UpgradeSystem upgradeSystem;

    float truckSpeed, truckFuel, truckRate;
    int truckCapacity, money, day;
    int speedCounter, fuelCounter, capacityCounter, rateCounter;

    private void Awake()
    {
        gameManager = GameManager.instance;
    }


    public void SaveTruckStat()
    {
        float speed = gameManager.GetTruckSpeed();
        float fuel = gameManager.GetTruckFuel();
        int capacity = gameManager.GetTruckMaxCapacity();
        float rate = gameManager.GetTruckCollectRate();

        PlayerPrefs.SetFloat("TruckSpeed", speed);
        PlayerPrefs.SetFloat("TruckFuel", fuel);
        PlayerPrefs.SetInt("TruckCapacity", capacity);
        PlayerPrefs.SetFloat("TruckRate", rate);
         
        PlayerPrefs.Save();
    }

    public void SaveMoney()
    {
        var money = gameManager.GetPlayerMoney();
        
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();
    }

    public void SaveDay()
    {
        var day = gameManager.GetDayValue();
        
        PlayerPrefs.SetInt("Day", day);
        PlayerPrefs.Save();
    }

    public void SaveSpeedCounter()
    {
        var speedCounter = gameManager.GetSpeedUpgradeCounter();

        PlayerPrefs.SetInt("SpeedCounter", speedCounter);
        PlayerPrefs.Save();
    }

    public void SaveFuelCounter()
    {
        var fuelCounter = gameManager.GetFuelUpgradeCounter();

        PlayerPrefs.SetInt("FuelCounter", fuelCounter);
        PlayerPrefs.Save();
    }

    public void SaveCapacityCounter()
    {
        var capacityCounter = gameManager.GetCapacityUpgradeCounter();

        PlayerPrefs.SetInt("CapacityCounter", capacityCounter);
        PlayerPrefs.Save();
    }

    public void SaveRateCounter()
    {
        var rateCounter = gameManager.GetCollectRateUpgradeCounter();

        PlayerPrefs.SetInt("RateCounter", rateCounter);
        PlayerPrefs.Save();
    }
    
    public bool CheckFileExist()
    {
        if(PlayerPrefs.HasKey("TruckSpeed"))
        {
            LoadSaveFiles();
            display();
            return true;
        }
        else
        {
            
            return false;
        }

    }

    private void Update()
    {
        //Debug.Log("Speed: " + PlayerPrefs.GetFloat("TruckSpeed"));
        //Debug.Log("Money: " + PlayerPrefs.GetInt("Money"));
    }

    public void LoadSaveFiles()
    {
        //load truck
        truckSpeed = PlayerPrefs.GetFloat("TruckSpeed");
        truckFuel = PlayerPrefs.GetFloat("TruckFuel");
        truckCapacity = PlayerPrefs.GetInt("TruckCapacity");
        truckRate = PlayerPrefs.GetFloat("TruckRate");

        gameManager.SetTruckStat(truckSpeed, truckFuel, truckCapacity, truckRate);

        //load money
        money = PlayerPrefs.GetInt("Money");
        gameManager.SetMoneyStat(money);

        //load day
        day = PlayerPrefs.GetInt("Day");
        gameManager.SetDayStat(day);

        //load UpgradeCounters
        speedCounter = PlayerPrefs.GetInt("SpeedCounter");
        fuelCounter = PlayerPrefs.GetInt("FuelCounter");
        capacityCounter = PlayerPrefs.GetInt("CapacityCounter");
        rateCounter = PlayerPrefs.GetInt("RateCounter");
        
        gameManager.SetSpeedCounter(speedCounter);
        gameManager.SetFuelCounter(fuelCounter);
        gameManager.SetCapacityCounter(capacityCounter);
        gameManager.SetCollectRateCounter(rateCounter);


    }

    public void display()
    {
        moneyCounter.UpdateText(money);
        dayCounter.SetText(day.ToString());
        displayTruckStat.SetText(truckSpeed, truckFuel, truckCapacity, truckRate);
    }

    public void SaveAll()
    {
        SaveMoney();
        SaveTruckStat();
        SaveDay();
    }


    public void CreateNewSave()
    {
        PlayerPrefs.DeleteAll();

        GameManager.instance.LoadBase();

        SaveMoney();
        SaveTruckStat();
        SaveDay();
        SaveSpeedCounter();
        SaveFuelCounter();
        SaveCapacityCounter();
        SaveRateCounter();

        LoadSaveFiles();
        display();
        upgradeSystem.SetUpgradeStat();
        upgradeSystem.DisplayAllUpgradeCounter();
    }
}
