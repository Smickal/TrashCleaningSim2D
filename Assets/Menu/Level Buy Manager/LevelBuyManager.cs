using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuyManager : MonoBehaviour
{
    GameManager gameManager;
    EconomySystem economySystem;


    ErrorObjectPooling errorObjectPooling;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        economySystem = FindObjectOfType<EconomySystem>();

    }

    private void Start()
    {
        economySystem.SetMoneyValue(gameManager.GetPlayerMoney());
    }

    public void BuyThisLevel(int value)
    {
        int levelCost = gameManager.GetLevelCost(value);


        if(economySystem.DecreaseMoney(levelCost))
        {
            gameManager.ActivateLevel(value);
        }
    }
}
