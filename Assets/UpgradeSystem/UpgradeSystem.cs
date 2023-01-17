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

    [Header("Others")]
    [SerializeField] DisplayTruckStat displayTruckStat;

    GameManager gameManager;
    EconomySystem economySystem;

    int speedUpradeCounter = 0;
    int fuelUpgradesCounter = 0;
    int capacityUpgradesCounter = 0;
    int collectUpgradesCounter = 0;

    private void Awake()
    {
        gameManager = GameManager.instance;
        economySystem = FindObjectOfType<EconomySystem>();
    }

    private void Start()
    {
        //tobeadded --> Save and Load UpgradeCounters

        CheckUpgradeCounter();
    }

    private void CheckUpgradeCounter()
    {
        if(speedUpradeCounter > maxUpgradeSpeed)
        {
            speedButton.enabled = false;
        }

        if (fuelUpgradesCounter > maxUpgradeFuel)
        {
            fuelButton.enabled = false;
        }

        if(capacityUpgradesCounter > maxUpgradeCapacity)
        {
            capacityButton.enabled = false;
        }

        if(collectUpgradesCounter > maxUpgradeCollectRate)
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
        if(speedUpradeCounter <= maxUpgradeSpeed)
        {
            if(economySystem.DecreaseMoney(priceSpeed))
            {
                float upgradedSpeed = gameManager.GetTruckSpeed() + upgradeSpeed;

                gameManager.SetTruckSpeed(upgradedSpeed);
                displayTruckStat.SetTextSpeed(upgradedSpeed);
                speedUpradeCounter++;
            }
        }
        else
        {
            speedButton.enabled = false;
        }
    }

    public void UpgradeFuel()
    {
        if(fuelUpgradesCounter <= maxUpgradeFuel)
        {
            if(economySystem.DecreaseMoney(priceFuel))
            {
                float upgradedFuel = gameManager.GetTruckFuel() + upgradeFuel;

                gameManager.SetTruckFuel(upgradedFuel);
                displayTruckStat.SetFuelText(upgradedFuel);
                fuelUpgradesCounter++;
            }
        }
        else
        {
            fuelButton.enabled = false;
        }
    }

    public void UpgradeCapacity()
    {
        if(capacityUpgradesCounter <= maxUpgradeCapacity)
        {
            if(economySystem.DecreaseMoney(priceCapacity))
            {
                int upgradedCapacity = gameManager.GetTruckMaxCapacity() + upgradeCapacity;

                gameManager.SetTruckCapacity(upgradedCapacity);
                displayTruckStat.SetCapacityText(upgradedCapacity);
                capacityUpgradesCounter++;
            }
        }
        else
        {
            capacityButton.enabled = false;
        }
    }

    public void UpgradeRate()
    {
        if(collectUpgradesCounter <= maxUpgradeCollectRate)
        {
            if(economySystem.DecreaseMoney(priceCollectRate))
            {
                float upgradedCollectRate = gameManager.GetTruckCollectRate() - upgradeCollectRate;

                gameManager.SetTruckCollectRate(upgradedCollectRate);
                displayTruckStat.SetCollectRate(upgradedCollectRate);
                collectUpgradesCounter++;
            }
        }
        else
        {
            collectRateButton.enabled = false;
        }
    }
}
