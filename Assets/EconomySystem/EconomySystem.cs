using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomySystem : MonoBehaviour
{
    // Start is called before the first frame update

    int playerMoney;

    [Header("Error_Initialization")]
    [SerializeField] ErrorObjectPooling cashNotEnoughError;

    [SerializeField] MoneyCounter moneyCounter;
    GameManager gameManager;
    private void Awake()
    {
        if(!moneyCounter) moneyCounter = FindObjectOfType<MoneyCounter>();
        gameManager = FindObjectOfType<GameManager>();
    }


    private void Start()
    {
        playerMoney = gameManager.GetPlayerMoney();
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


    public void SetMoneyValue(int value)
    {
        playerMoney = value;
    }


    public int GetMoneyValue()
    {
        return playerMoney;
    }
}
