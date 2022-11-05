using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Waypoint[] waypoints;

    private int[] placeStamp;

    Waypoint startingPath, endingPath;
    private void Awake()
    {   
        waypoints = GetComponentsInChildren<Waypoint>();
        placeStamp = new int[waypoints.Length];
        //Debug.Log(waypoints.Length);
    }
    

    //generate random StartingPos and EndingPos
    //kasih startingposnya dan ending posnya ke car
    //Generate pathnya 

    public Waypoint GenerateStartingPosition()
    {
        int randomIdx;
        do
        {
           randomIdx = Random.Range(0, waypoints.Length - 1);

        }while(placeStamp[randomIdx] != 0);

        placeStamp[randomIdx] = 1;
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
