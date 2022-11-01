using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrafficLightSystem4 : MonoBehaviour
{
    // Start is called before the first frame update
    //Light_1
    [SerializeField] TextMeshPro textLight1;
    //Light_2
    [SerializeField] TextMeshPro textLight2;
    //light3
    [SerializeField] TextMeshPro textLight3;
    //light4
    [SerializeField] TextMeshPro textLight4;

    [SerializeField] float trafficCountdown = 10f;
    [SerializeField] float offset = 0.2f;
    [SerializeField] LayerMask carAILayer;

    BoxCollider2D[] allLaneCol;

    int curLightIdx = 0;
    float curCountdown = 0f;

    bool light1 = false;
    bool light2 = false;
    bool light3 = false;
    bool light4 = false;

    private void Awake()
    {
        allLaneCol = GetComponentsInChildren<BoxCollider2D>();
    }

    void Start()
    {
        int ranNum = Random.Range(1, 3);
        ActivateLight(ranNum);
        curCountdown = trafficCountdown;
        curLightIdx = ranNum;
    }

    private void Update()
    {
        ProcessSwitchLight();
        ProcessActivateLane();
    }

    private void ProcessActivateLane()
    {
        if (light1 && !light3 && !light2 && !light4)
        {
            //activate lane1
            ActivateLane(1);   
        }
        if (!light1 && light2 && !light3 && !light4)
        {
            //activate lane2
            ActivateLane(2);          
        }
        if(!light1 && light3 && !light2 && !light4)
        {
            ActivateLane(3);
        }
        if(!light1 && !light3 && !light2 && light4)
        {
            ActivateLane(4);
        }
    }

    private void ActivateLane(int num)
    {
        Collider2D[] tempCol = Physics2D.OverlapCircleAll(allLaneCol[num - 1].transform.position, offset, carAILayer);
        foreach (Collider2D carCol in tempCol)
        {
            carCol.GetComponent<CarAI>().Move = true;
        }
    }

    private void ProcessSwitchLight()
    {
        if (curCountdown <= 0f)
        {
            //change light
            curLightIdx++;
            if (curLightIdx > 4)
            {
                curLightIdx = 1;
            }
            ActivateLight(curLightIdx);
            curCountdown = trafficCountdown;
        }
        else
        {
            //kurangin waktuCountdown
            curCountdown -= Time.deltaTime;
        }
    }

    private void ActivateLight(int num)
    {
        if (num == 1)
        {
            textLight1.text = "jalan";
            textLight2.text = "Stop";
            textLight3.text = "Stop";
            textLight4.text = "Stop";

            light1 = true;
            light2 = false;
            light3 = false;
            light4 = false;

        }
        else if (num == 2)
        {
            textLight1.text = "Stop";
            textLight2.text = "jalan";
            textLight3.text = "Stop";
            textLight4.text = "Stop";

            light1 = false;
            light2 = true;
            light3 = false;
            light4 = false;
        }
        else if(num == 3)
        {
            textLight1.text = "Stop";
            textLight2.text = "Stop";
            textLight3.text = "Jalan";
            textLight4.text = "Stop";

            light1 = false;
            light2 = false;
            light3 = true;
            light4 = false;
        }
        else if(num == 4)
        {
            textLight1.text = "Stop";
            textLight2.text = "Stop";
            textLight3.text = "Stop";
            textLight4.text = "Jalan";

            light1 = false;
            light2 = false;
            light3 = false;
            light4 = true;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    if (allLaneCol.Length > 0)
    //    {
    //        Gizmos.DrawSphere(allLaneCol[curLightIdx - 1].transform.position, offset);
    //        Gizmos.DrawSphere(allLaneCol[curLightIdx + 1].transform.position, offset);
    //    }
    //}


    public bool IsThisLaneActivated(int laneNum)
    {
        if (curLightIdx == laneNum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
