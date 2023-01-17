using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTruckStat : MonoBehaviour
{
    // Start is called before the first frame update


    GameManager gameManager;

    Movement truckMovement;
    TakeGarbage truckTakeGarbage;
    FuelSystem truckFuelSystem;


    float truckSpeed;
    float truckFuel;
    int truckMaxCapacity;
    float truckCollectRate;

    private void Awake()
    {
        gameManager = GameManager.instance;

        truckMovement = GetComponent<Movement>();
        truckTakeGarbage= GetComponent<TakeGarbage>();
        truckFuelSystem= GetComponent<FuelSystem>();
    }

    void Start()
    {
        SetStats();
    }

   
    private void SetStats()
    {
        truckMovement.SetSpeed(gameManager.GetTruckSpeed());

        truckFuelSystem.SetMaxFuel(gameManager.GetTruckFuel());
        truckFuelSystem.RefillFuel(0);

        truckTakeGarbage.SetMaxCapacityAndRate(gameManager.GetTruckMaxCapacity(), gameManager.GetTruckCollectRate());
       
    }
}
