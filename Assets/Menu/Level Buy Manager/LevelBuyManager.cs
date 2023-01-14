using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuyManager : MonoBehaviour
{
    GameManager gameManager;
    EconomySystem economySystem;

    [SerializeField] SwipeMenu swipeMenu;
    [SerializeField] GameObject levelCostLevel2;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        economySystem = FindObjectOfType<EconomySystem>();

    }

    private void Start()
    {
        economySystem.SetMoneyValue(gameManager.GetPlayerMoney());
    }

    public void BuyThisLevel()
    {
        int currentLevel = swipeMenu.GetCurrentLevel() + 1;    
        int levelCost = gameManager.GetLevelCost(currentLevel);

        Debug.Log("CurrentLevel: " + currentLevel + ",LevelCost: " + levelCost);


        if(economySystem.DecreaseMoney(levelCost) && !gameManager.CheckLevel(currentLevel))
        {
            gameManager.ActivateLevel(currentLevel);
            levelCostLevel2.SetActive(false);
        }
    }
}
