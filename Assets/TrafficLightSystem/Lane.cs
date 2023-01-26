using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int laneNum = 0;
    [SerializeField] LayerMask carLayer;
    [SerializeField] bool isLane4System = false;

    float carSpeed;

    TrafficLightSystem3 tlSystem3;
    TrafficLightSystem4 tlSystem4;

    Movement carMove;
    private void Awake()
    {
        if (!isLane4System)
            tlSystem3 = GetComponentInParent<TrafficLightSystem3>();
        else
            tlSystem4 = GetComponentInParent<TrafficLightSystem4>();


        carMove = FindObjectOfType<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CarAI>())
        {
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

        Movement mov;

        if (collision.GetComponent<Movement>())
        {
            mov = collision.GetComponent<Movement>();
            //if lane stop and car moved <-- punishment
            Debug.Log(mov.GetVerticalaxis() + " " + tlSystem3.IsThisLaneActivated(laneNum));
            if (!tlSystem3.IsThisLaneActivated(laneNum) && Mathf.Abs(carSpeed) > 0f)
            {
                FindObjectOfType<EconomySystem>().DecreaseMoney(20);
                FindObjectOfType<AudioManager>().PlaySound("TrafficViolation");
                Debug.Log("decresead money");
            }
        }
    }


    private void Update()
    {
        carSpeed = carMove.GetVerticalaxis();
    }
}
