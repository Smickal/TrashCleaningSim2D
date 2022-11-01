using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int carSize = 10;
    [SerializeField] GameObject car;
    void Start()
    {
        for(int i = 0; i <carSize; i++)
        {
            Instantiate(car, transform);
        }
    }

 
}
