using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int laneNum = 0;
    [SerializeField] LayerMask carLayer;
    [SerializeField] bool isLane4System = false;

    TrafficLightSystem3 tlSystem3;
    TrafficLightSystem4 tlSystem4;
    private void Awake()
    {
        if (!isLane4System)
            tlSystem3 = GetComponentInParent<TrafficLightSystem3>();
        else
            tlSystem4 = GetComponentInParent<TrafficLightSystem4>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CarAI>())
        {
            Debug.Log("car");
            if(!isLane4System)
            {
                if (tlSystem3.IsThisLaneActivated(laneNum))
                {
                    collision.GetComponent<CarAI>().Move = true;
                }
                else
                {
                    collision.GetComponent<CarAI>().Move = false;
                }
            }
            else
            {
                if (tlSystem4.IsThisLaneActivated(laneNum))
                {
                    collision.GetComponent<CarAI>().Move = true;
                }
                else
                {
                    collision.GetComponent<CarAI>().Move = false;
                }

            }

            
        }
    }
}
