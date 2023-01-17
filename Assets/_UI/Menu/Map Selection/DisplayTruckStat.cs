using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTruckStat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI topSpeedText;
    [SerializeField] TextMeshProUGUI maxFuelText;
    [SerializeField] TextMeshProUGUI maxCapacityText;
    [SerializeField] TextMeshProUGUI collectRateText;


   GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();  
    }


    private void Start()
    {
        SetText(gameManager.GetTruckSpeed(), gameManager.GetTruckFuel(), gameManager.GetTruckMaxCapacity(), gameManager.GetTruckCollectRate());
    }
    public void SetText(float topSpeed, float maxFuel, int maxCapacity, float collectRate)
    {
        topSpeedText.text = topSpeed.ToString();
        maxFuelText.text = maxFuel.ToString();
        maxCapacityText.text = maxCapacity.ToString();
        collectRateText.text = collectRate.ToString() + " seconds";
    }


    public void SetTextSpeed(float topSpeed)
    {
        topSpeedText.text = topSpeed.ToString();
    }

    public void SetFuelText(float fuel)
    {
        maxFuelText.text = fuel.ToString();
    }

    public void SetCapacityText(int capacity)
    {
        maxCapacityText.text = capacity.ToString();
    }

    public void SetCollectRate(float rate)
    {
        collectRateText.text = rate.ToString() + " seconds";
    }
}
