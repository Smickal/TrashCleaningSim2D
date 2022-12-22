using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int carSize = 10;
    [SerializeField] GameObject car;
    
    List<GameObject> cars = new List<GameObject>();

    int carsSpawned = 0;

    public void SpawnTrafficCar()
    {
        for (int i = 0; i < carSize; i++)
        {
            GameObject newObj =  Instantiate(car, transform);
            cars.Add(newObj);
            carsSpawned++;
        }
    }

    public void DespawnCar()
    {
        for (int i = 0; i < carsSpawned; i++)
        {
            Destroy(cars[i]);
        }
        cars.Clear();
        carsSpawned = 0;
    }
}
