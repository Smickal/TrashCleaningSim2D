using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Waypoint[] waypoints;

    Waypoint startingPath, endingPath;
    private void Awake()
    {
        waypoints = GetComponentsInChildren<Waypoint>();
        //Debug.Log(waypoints.Length);
    }
    

    //generate random StartingPos and EndingPos
    //kasih startingposnya dan ending posnya ke car
    //Generate pathnya 

    public Waypoint GenerateStartingPosition()
    {
        int randomIdx = Random.Range(0, waypoints.Length - 1);
        //Debug.Log(waypoints[randomIdx]);
        startingPath = waypoints[randomIdx];
        return waypoints[randomIdx];
    }

    public Waypoint GenerateEndingPosition()
    {
        int randomIdx;
        do
        {
            randomIdx = Random.Range(0, waypoints.Length - 1);
        } 
        while (endingPath == startingPath);

        endingPath = waypoints[randomIdx];
        return waypoints[randomIdx];
    }

    

}
