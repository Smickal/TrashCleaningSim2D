using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI dayText;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    void Start()
    {
        SetText(gameManager.GetDayValue().ToString());
    }

    public void SetText(string text)
    {
        dayText.text = text;
    }
}
