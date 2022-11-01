using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CarCostumize : MonoBehaviour
{
    public GameObject[] carPrefabs;

    private void Start()
    {
        Instantiate(SelectACarPrefab(), transform);
    }

    public GameObject SelectACarPrefab()
    {
        var randomIdx = Random.Range(0, carPrefabs.Length);
        return carPrefabs[randomIdx];
    }
}
