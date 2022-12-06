using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomySystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int playerMoney = 100000;


    [Header("Error_Initialization")]
    [SerializeField] ErrorObjectPooling cashNotEnoughError;
    MoneyCounter moneyCounter;

    private void Awake()
    {
        moneyCounter = FindObjectOfType<MoneyCounter>();
    }


    private void Start()
    {
        moneyCounter.UpdateText(playerMoney);
    }

    
    public bool DecreaseMoney(int value)
    {
        if (!IsMoneyEnough(value))
        {
            
            return false;
        }
        playerMoney -= value;
        moneyCounter.UpdateText(playerMoney);
        return true;
    }

    public void AddMoney(int value)
    {
        playerMoney += value;
        moneyCounter.UpdateText(playerMoney);
    }

    public bool IsMoneyEnough(int value)
    {
        if (playerMoney < value)
        {
            cashNotEnoughError.TriggerError();
            return false;
        }
        else
            return true;
    }
}
