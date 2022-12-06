using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int retryCost = 5000;
    [SerializeField] TextMeshProUGUI RetryCostText;

    EconomySystem economySystem;
    FuelSystem fuelSystem;

    private void Awake()
    {
        economySystem = FindObjectOfType<EconomySystem>();
        fuelSystem = FindObjectOfType<FuelSystem>();
    }

    private void Start()
    {
        SetRetryCostText();
    }

    private void SetRetryCostText()
    {
        int totalCost = retryCost + fuelSystem.GetFuelCost();
        RetryCostText.text = "$"+totalCost.ToString();
    }

    public int GetRetryCost()
    {
        return retryCost;
    }
}
