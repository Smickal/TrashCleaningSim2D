using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToNearest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;
    [SerializeField] GameObject arrowIndicator;
    [SerializeField] GameObject obj;
    [SerializeField] float rotaionSpeed = 1f;

    GasStation[] gasStations;
    GasStation closestGasStation;

    private void Awake()
    {
        gasStations = FindObjectsOfType<GasStation>();
        closestGasStation = gasStations[0];       
    }

    private void Start()
    {
        DeActivateArrowIndicator();
    }

    // Update is called once per frame
    void Update()
    {
        SearchClosestGasStation();
        ProcessArrowRotation();
    }

    private void ProcessArrowRotation()
    {
        Transform target = closestGasStation.transform;
        Transform car = player.transform;

        Vector2 direction = (target.position - car.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        arrowIndicator.transform.rotation = Quaternion.Lerp(arrowIndicator.transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotaionSpeed);

    }

    private void SearchClosestGasStation()
    {
        foreach(GasStation gasStation in gasStations)
        {
            if(Vector2.Distance(closestGasStation.transform.position, player.transform.position) > 
                Vector2.Distance(gasStation.transform.position, player.transform.position))
            {
                closestGasStation = gasStation;
            }
        }
    }

    public void ActivateArrowIndicator()
    {
        obj.SetActive(true);
    }

    public void DeActivateArrowIndicator()
    {
        obj.SetActive(false);
    }
}
