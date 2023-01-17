using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrashSnap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] obj;


    [SerializeField] Transform[] allSpawnSpot;
    [SerializeField] TakeGarbage takeGarbage;


    bool[] spawned;
    int garbageCounted = 0;



    private void Start()
    {
        
    }

    public void SpawnTrash()
    {
        int maxDump = takeGarbage.GetCurrentDump();
        int maxSpawnLoc = allSpawnSpot.Length;
        spawned = new bool[allSpawnSpot.Length];

        int spawnedTrash = 0;
        while(spawnedTrash < maxDump)
        {
            int randomSpawnLoc = UnityEngine.Random.Range(1, maxSpawnLoc);
            if (spawned[randomSpawnLoc] == false)
            {
                //spawn sampah
                //SpawnedTrash nambah

                Instantiate(GetRandomTrash(), allSpawnSpot[randomSpawnLoc]);
                spawnedTrash++;
                spawned[randomSpawnLoc] = true;
            }

        }
    }

    public GameObject GetRandomTrash()
    {
        int randomNum = UnityEngine.Random.Range(0, obj.Length);
        return obj[randomNum];
    }


    public void IncreaseGarbageCounted()
    {
        garbageCounted++;
    }
}
