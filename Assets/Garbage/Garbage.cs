using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garbage : MonoBehaviour
{

    GarbageSpawnerSystem GarbageSpawnerSystem;


    private void Awake()
    {
        GarbageSpawnerSystem = GetComponentInParent<GarbageSpawnerSystem>();
    }


    public void TakeTrash()
    {
        GarbageSpawnerSystem.DecreaseSpawnedGarbage(transform);
        Destroy(gameObject);
    }

}
