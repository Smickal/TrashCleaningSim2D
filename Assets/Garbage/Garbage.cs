using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    // Start is called before the first frame update
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
