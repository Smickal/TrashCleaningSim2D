using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GarbageCounter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI counterText;

    int maxDump;
    

    // Update is called once per frame
    public void StartUp(int maxDump)
    {
        this.maxDump = maxDump;
        counterText.text = "0/ " + maxDump;
    }


    public void UpdateText(int value)
    {
        counterText.text = value.ToString() + "/ " + maxDump;
    }
}
