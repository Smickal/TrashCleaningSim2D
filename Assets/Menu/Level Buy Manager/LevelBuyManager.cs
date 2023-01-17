using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBuyManager : MonoBehaviour
{
    GameManager gameManager;
    EconomySystem economySystem;

    [SerializeField] SwipeMenu swipeMenu;
    [SerializeField] GameObject levelCostLevel2;

    private void Awake()
    {
        gameManager = GameManager.instance;
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

        swipeMenu.CheckLevel();

        FindObjectOfType<SaveSystem>().SaveAll();


    }

    public void PlayThisLevel()
    {
        int curLevel = swipeMenu.GetCurrentLevel() + 1;
        SceneManager.LoadScene(curLevel);
    }
}
