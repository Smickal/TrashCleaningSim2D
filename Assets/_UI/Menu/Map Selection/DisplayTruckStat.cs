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


   

    public void SetText(float topSpeed, float maxFuel, int maxCapacity, float collectRate)
    {
        topSpeedText.text = topSpeed.ToString();
        maxFuelText.text = maxFuel.ToString();
        maxCapacityText.text = maxCapacity.ToString();
        collectRateText.text = collectRate.ToString();
    }
}
