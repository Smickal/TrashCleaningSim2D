using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;

    int maxDump;


    // Update is called once per frame

    

    public void UpdateText(int value)
    {
        moneyText.text =  value.ToString();
    }
}
