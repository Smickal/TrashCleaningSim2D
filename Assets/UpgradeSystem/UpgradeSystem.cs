using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Speed")]
    [SerializeField] int maxUpgradeSpeed = 5;
    [SerializeField] float upgradeSpeed = 2;
    [SerializeField] int priceSpeed = 100;

    [Header("Fuel")]
    [SerializeField] int maxUpgradeFuel = 5;
    [SerializeField] float upgradeFuel = 10;
    [SerializeField] int priceFuel = 110;

    [Header("Capacity")]
    [SerializeField] int maxUpgradeCapacity = 5;
    [SerializeField] int upgradeCapacity = 2;
    [SerializeField] int priceCapacity = 100;

    [Header("CollectRate")]
    [SerializeField] int maxUpgradeCollectRate= 5;
    [SerializeField] float upgradeCollectRate = 2;
    [SerializeField] int priceCollectRate = 100;
    
    [Header("Button")]
    [SerializeField] Button speedButton;
    [SerializeField] Button fuelButton;
    [SerializeField] Button capacityButton;
    [SerializeField] Button collectRateButton;

    [Header("UI")]
    [SerializeField] DisplayTruckStat displayTruckStat;
    [SerializeField] TextMeshProUGUI speedCounterText;
    [SerializeField] TextMeshProUGUI fuelCounterText;
    [SerializeField] TextMeshProUGUI capacityCounterText;
    [SerializeField] TextMeshProUGUI collectRateCounterText;

    GameManager gameManager;
    EconomySystem economySystem;
    SaveSystem saveSystem;


    int speedUpradeCounter = 0;
    int fuelUpgradesCounter = 0;
    int capacityUpgradesCounter = 0;
    int collectUpgradesCounter = 0;

    private void Awake()
    {
        gameManager = GameManager.instance;
        saveSystem = FindObjectOfType<SaveSystem>();
        economySystem = FindObjectOfType<EconomySystem>();
    }

    private void Start()
    {
        //tobeadded --> Save and Load UpgradeCounters

        CheckUpgradeCounter();
        DisplayAllUpgradeCounter();
    }

    public void SetUpgradeStat()
    {
        speedUpradeCounter = gameManager.GetSpeedUpgradeCounter();
        fuelUpgradesCounter = gameManager.GetFuelUpgradeCounter();
        capacityUpgradesCounter = gameManager.GetFuelUpgradeCounter();
        collectUpgradesCounter = gameManager.GetCollectRateUpgradeCounter();
    }

    private void CheckUpgradeCounter()
    {
        SetUpgradeStat();
          
        if(speedUpradeCounter >= maxUpgradeSpeed)
        {
            speedButton.enabled = false;
        }

        if (fuelUpgradesCounter >= maxUpgradeFuel)
        {
            fuelButton.enabled = false;
        }

        if(capacityUpgradesCounter >= maxUpgradeCapacity)
        {
            capacityButton.enabled = false;
        }

        if(collectUpgradesCounter >= maxUpgradeCollectRate)
        {
            collectRateButton.enabled = false;
        }
    }


    public void UpgradeSpeed()
    {
        //checkduit
        //upgrademobil
        //update text
        //disable button klo dah max
        if(speedUpradeCounter < maxUpgradeSpeed)
        {
            if(economySystem.DecreaseMoney(priceSpeed))
            {
                float upgradedSpeed = gameManager.GetTruckSpeed() + upgradeSpeed;

                gameManager.SetTruckSpeed(upgradedSpeed);
                displayTruckStat.SetTextSpeed(upgradedSpeed);
                speedUpradeCounter++;
                DisplaySpeedCounter();
                gameManager.SetSpeedCounter(speedUpradeCounter);
                saveSystem.SaveSpeedCounter();

                if(speedUpradeCounter >= maxUpgradeSpeed) speedButton.enabled = false;
            }
        }
    }

    public void UpgradeFuel()
    {
        if(fuelUpgradesCounter < maxUpgradeFuel)
        {
            if(economySystem.DecreaseMoney(priceFuel))
            {
                float upgradedFuel = gameManager.GetTruckFuel() + upgradeFuel;

                gameManager.SetTruckFuel(upgradedFuel);
                displayTruckStat.SetFuelText(upgradedFuel);
                fuelUpgradesCounter++;
                DisplayFuelCounter();
                gameManager.SetFuelCounter(fuelUpgradesCounter);
                saveSystem.SaveFuelCounter();

                if(fuelUpgradesCounter >= maxUpgradeFuel) fuelButton.enabled = false;
            }
        }
        else
        {
            fuelButton.enabled = false;
        }
    }

    public void UpgradeCapacity()
    {
        if(capacityUpgradesCounter < maxUpgradeCapacity)
        {
            if(economySystem.DecreaseMoney(priceCapacity))
            {
                int upgradedCapacity = gameManager.GetTruckMaxCapacity() + upgradeCapacity;

                gameManager.SetTruckCapacity(upgradedCapacity);
                displayTruckStat.SetCapacityText(upgradedCapacity);
                capacityUpgradesCounter++;
                DisplayCapacityCounter();
                gameManager.SetCapacityCounter(capacityUpgradesCounter);
                saveSystem.SaveCapacityCounter();

                if(capacityUpgradesCounter >= maxUpgradeCapacity) capacityButton.enabled= false;
            }
        }
        else
        {
            capacityButton.enabled = false;
        }
    }

    public void UpgradeRate()
    {
        if(collectUpgradesCounter < maxUpgradeCollectRate)
        {
            if(economySystem.DecreaseMoney(priceCollectRate))
            {
                float upgradedCollectRate = gameManager.GetTruckCollectRate() - upgradeCollectRate;

                gameManager.SetTruckCollectRate(upgradedCollectRate);
                displayTruckStat.SetCollectRate(upgradedCollectRate);
                collectUpgradesCounter++;
                DisplayCollectRateCounter();
                gameManager.SetCollectRateCounter(collectUpgradesCounter);
                saveSystem.SaveRateCounter();

                if(collectUpgradesCounter >= maxUpgradeCollectRate) collectRateButton.enabled= false;
            }
        }
        else
        {
            collectRateButton.enabled = false;
        }
    }


    public void DisplaySpeedCounter()
    {
        speedCounterText.text = speedUpradeCounter.ToString() + "/ " + maxUpgradeSpeed.ToString();
    }

    public void DisplayFuelCounter()
    {
        fuelCounterText.text = fuelUpgradesCounter.ToString() + "/ " + maxUpgradeFuel.ToString();
    }

    public void DisplayCapacityCounter()
    {
        capacityCounterText.text = capacityUpgradesCounter.ToString() + " /" + maxUpgradeCapacity.ToString();
    }

    public void DisplayCollectRateCounter()
    {
        collectRateCounterText.text = collectUpgradesCounter.ToString() + " /" + maxUpgradeCollectRate.ToString();
    }

    public void DisplayAllUpgradeCounter()
    {
        DisplaySpeedCounter();
        DisplayFuelCounter();
        DisplayCapacityCounter();
        DisplayCollectRateCounter();
    }

    public void NewUpgrade()
    {
        speedButton.enabled = true;
        fuelButton.enabled = true;
        capacityButton.enabled = true;
        collectRateButton.enabled = true;
    }
}
