using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class FuelSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] FuelDisplay fuelDisplay;

    [Header("Fuel")]
    [SerializeField] int fuelPrice = 200;
    [SerializeField] float maxFuel = 100f;
    [SerializeField] float decreaseRate = 0.2f;

    [Header("UI")]
    [SerializeField] float fuelDetectRange = 2.5f;
    [Range(0, 1)][SerializeField] float blinkThreshold;

    [Header("Inizialization")]
    [SerializeField] Button refuelButton;
    [SerializeField] LayerMask gasStationMask;
    [SerializeField] PopUpController refuelControllerPop;
    [SerializeField] TextMeshProUGUI RefuelCostText;
    [SerializeField] PopUpController outOfFuelPop;
    [SerializeField] TextMeshProUGUI retryCostText;

    float currentFuel;
    bool isTrigger = false;
    GasStation gasStation;
    EconomySystem economySystem;
    Movement movement;
    RotateToNearest rotateToNearest;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        economySystem = FindObjectOfType<EconomySystem>();
        rotateToNearest = FindObjectOfType<RotateToNearest>();
        movement = GetComponent<Movement>();
    }

    void Start()
    {
        currentFuel = maxFuel;
        RefuelCostText.text = "$" + fuelPrice.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckGasStationRange();

    }
    void CheckGasStationRange()
    {
        Collider2D gasStationCol = Physics2D.OverlapCircle(transform.position, fuelDetectRange, gasStationMask);      
        if(gasStationCol && currentFuel < maxFuel)
        {
            gasStation = gasStationCol.gameObject.GetComponent<GasStation>();
            refuelButton.gameObject.SetActive(true);
        }
        else
        {
            refuelButton.gameObject.SetActive(false);
            gasStation = null;
        }
    }

    public void DecreaseFuel()
    {
        currentFuel -= decreaseRate * Time.deltaTime;
        fuelDisplay.SetFuelSlider(currentFuel, maxFuel);


        if (currentFuel <= maxFuel * blinkThreshold)
        {
            fuelDisplay.ActivateBlinking(true);
            rotateToNearest.ActivateArrowIndicator();
        }

        if(currentFuel <= 0f && !isTrigger)
        {
            movement.IsFuelEmpty(true);
            outOfFuelPop.TriggerFadeIn();
            isTrigger = true;
        }
    }

    public void RefillFuel()
    {
        if (!economySystem.DecreaseMoney(fuelPrice))
            return;
        
        currentFuel = maxFuel;
        fuelDisplay.SetFuelSlider(currentFuel, maxFuel);
        rotateToNearest.DeActivateArrowIndicator();
        fuelDisplay.ActivateBlinking(false);
        movement.IsFuelEmpty(false);
        refuelControllerPop.TriggerFadeOut();
        isTrigger = false;
    }

    public void RefillFuel(int value)
    {
        if (!economySystem.DecreaseMoney(value))
            return;

        currentFuel = maxFuel;
        fuelDisplay.SetFuelSlider(currentFuel, maxFuel);
        rotateToNearest.DeActivateArrowIndicator();
        fuelDisplay.ActivateBlinking(false);
        movement.IsFuelEmpty(false);
        refuelControllerPop.TriggerFadeOut();
        isTrigger = false;
    }

    public void TeleportToTheNearestGasStation()
    {
        int totalDerekValue = fuelPrice + gameManager.GetRetryCost();

        if (!economySystem.IsMoneyEnough(totalDerekValue))
        {   
            return;
        }
        RefillFuel(totalDerekValue);
        

        GameObject[] gasStations = GameObject.FindGameObjectsWithTag("Gas Station");
        GameObject closestGasStation = gasStations[0];

        foreach (GameObject gasStation in gasStations)
        {
            if (Vector2.Distance(closestGasStation.transform.position, transform.position) >
                Vector2.Distance(gasStation.transform.position, transform.position))
            {
                closestGasStation = gasStation;
            }
        }

        transform.position = closestGasStation.GetComponent<GasStation>().SpawnPoint.position;
        transform.rotation = closestGasStation.GetComponent<GasStation>().SpawnPoint.rotation;

        outOfFuelPop.TriggerFadeOut();
    }
       
    public int GetFuelCost()
    {
        return fuelPrice;
    }

    public void SetFuelPrice(int value)
    {
        fuelPrice = value;
    }
}
