using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMoney : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;
    MapChanger mapChanger;

    [SerializeField] TextMeshProUGUI textCost;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        mapChanger = GetComponent<MapChanger>();
    }
    void Start()
    {
        textCost.text = "Cost: " + gameManager.GetLevelCost(mapChanger.GetLevel()).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
