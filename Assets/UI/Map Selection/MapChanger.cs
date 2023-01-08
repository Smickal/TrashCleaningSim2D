using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int level = 1;


    GameManager gameManager;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsThisLevelUnlocked()
    {
        if(gameManager.CheckLevel(level))
        {

        }

    }

    private void ChangeButton()
    {

    }
}
