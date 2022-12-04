using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomySystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int playerMoney = 100000;
    MoneyCounter moneyCounter;

    private void Awake()
    {
        moneyCounter = FindObjectOfType<MoneyCounter>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DecreaseMoney(int value)
    {
        playerMoney -= value;
        moneyCounter.UpdateText(playerMoney);
    }

    public void AddMoney(int value)
    {
        playerMoney += value;
        moneyCounter.UpdateText(playerMoney);
    }
}
