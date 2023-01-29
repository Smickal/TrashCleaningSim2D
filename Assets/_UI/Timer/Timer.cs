using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI minuteText;
    [SerializeField] TextMeshProUGUI secondText;

    [SerializeField] PopUpController finishedPopUpController;

    int minute;
    int second;

    float minuteCountdown;
    bool check = false;

    // Update is called once per frame
    void Update()
    {
        if (minuteCountdown < 0) return;
        minuteCountdown -= Time.deltaTime;

        ProcessCountdown();

        if(!check && minuteCountdown <= 0f)
        {
            finishedPopUpController.TriggerFadeIn();
            check = true;
        }
    }

    private void ProcessCountdown()
    {
        minute = (int)minuteCountdown / 60;
        minuteText.text = minute.ToString();

        second = (int)minuteCountdown % 60;
        secondText.text = second.ToString();
    }

    public void ResetCurrentSession()
    {
        minuteCountdown = FindObjectOfType<GameManager>().GetSessionLong();
        minuteCountdown *= 60;
        check = false;
    }
}
