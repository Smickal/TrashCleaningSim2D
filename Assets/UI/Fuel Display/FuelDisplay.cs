using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;


public class FuelDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Slider fuelSlider;
    [SerializeField] Image fuelIcon;


    [Header("Blinking Icon")]
    [SerializeField] float blinkinRate = 0.1f;
    [SerializeField] Color32 startColor;
    [SerializeField] Color32 endColor;

    [SerializeField] Color32 curColor;


    bool isIconBlink = false;
    bool isEndColor = false;

    float curTime = 0f;

    void Start()
    {
        fuelIcon.color = startColor;
        curColor = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessBlinkinIcon();
    }

    private void ProcessBlinkinIcon()
    {
        if(isIconBlink)
        {
            //startBlink
            if(Color32.Equals(curColor, endColor))
            {
                isEndColor = true;
                curTime = 0f;
            }

            if (Color32.Equals(curColor, startColor))
            {
                isEndColor = false;
                curTime = 0f;
            }

            curTime += Time.deltaTime;
            float percentage = curTime / blinkinRate;


            if(!isEndColor)
            {
                fuelIcon.color = Color32.Lerp(startColor, endColor, percentage);
            }
            else
            {
                fuelIcon.color = Color32.Lerp(endColor, startColor,  percentage);               
            }  
            curColor = fuelIcon.color;
        }
        else
        {
            fuelIcon.color = startColor;
        }
    }

    public void SetFuelSlider(float currentFuel, float maxfuel)
    {
        fuelSlider.value = currentFuel / maxfuel;   
    }

    public void ActivateBlinking(bool value)
    {
        isIconBlink = value;

        if(value == false)
        {
            //reset Color
            fuelIcon.color = startColor;
        }
    }



}
