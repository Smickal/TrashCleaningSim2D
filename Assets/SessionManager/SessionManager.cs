using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] DayAnimation dayAnim;
    [SerializeField] CarSpawner carSpawner;
    [SerializeField] TextMeshProUGUI textCost;
    [SerializeField] TextMeshProUGUI completDayText;

    GameManager gameManager;
    Transform player;
    Transform startingPosition;
    EconomySystem economySystem;
    FuelSystem fuelSystem;
    Timer timer;

    private void Awake()
    {
        

        
    }
    void Start()
    {
        InitializeInNewMap();
        SetRetryCostText();
        //ResetDaySession();

        dayAnim.StartDay(gameManager.GetDayValue());
        timer.ResetCurrentSession();
        player.position = startingPosition.position;
        player.rotation = startingPosition.rotation;
        carSpawner.DespawnCar();
        carSpawner.SpawnTrafficCar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetDaySession()
    {
        //Save Current Money
        economySystem.SetMoneyValue(gameManager.GetCurrentDayMoney());
        completDayText.text = $"Competed Day-{gameManager.GetDayValue()}";

        //Start Day Animation
        dayAnim.StartDay(gameManager.GetDayValue());

        //teleport player to Starting Point
        player.position = startingPosition.position;
        player.rotation = startingPosition.rotation;
        fuelSystem.RefillFuel(0);

        //reset timer
        timer.ResetCurrentSession();

        //respawn car

        carSpawner.DespawnCar();
        carSpawner.SpawnTrafficCar();

        


    }

    public void StartNextDaySession()
    {
        //Save Current Money
        gameManager.SaveCurrentDayMoney(economySystem.GetMoneyValue());

        //Increase Day
        gameManager.IncreaseDay();
        completDayText.text = $"Competed Day-{gameManager.GetDayValue()}";

        //Start Day Animation
        dayAnim.StartDay(gameManager.GetDayValue());

        //teleport player to Starting Point
        player.position = startingPosition.position;
        player.rotation = startingPosition.rotation;

        carSpawner.DespawnCar();
        carSpawner.SpawnTrafficCar();
        fuelSystem.RefillFuel(0);

        //reset timer
        timer.ResetCurrentSession();
    }


    public void InitializeInNewMap()
    {
        gameManager = GameManager.instance;
        player = FindObjectOfType<Movement>().transform;
        startingPosition = FindObjectOfType<StartingPosition>().transform;
        economySystem = FindObjectOfType<EconomySystem>();
        fuelSystem = FindObjectOfType<FuelSystem>();
        timer = FindObjectOfType<Timer>();


        economySystem.SetMoneyValue(gameManager.GetPlayerMoney());
        fuelSystem.SetFuelPrice(gameManager.GetFuelCost());

    }

    private void SetRetryCostText()
    {
        int totalCost = gameManager.GetRetryCost() + fuelSystem.GetFuelCost();
        textCost.text = "$" + totalCost.ToString();
    }
}
