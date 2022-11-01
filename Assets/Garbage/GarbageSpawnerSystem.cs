using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawnerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  int maxGarbageSpawned;
    [SerializeField] GameObject trash;

    Transform[] spawnPosition;

    int[] spawnLocNote;

    int spawnCount;
    int currSpawned;

    private void Awake()
    {
        spawnPosition = GetComponentsInChildren<Transform>();
        spawnLocNote = new int[spawnPosition.Length];
    }

    void Start()
    {
        spawnCount = spawnPosition.Length;
        SpawnTrash(maxGarbageSpawned);
    }

    // Update is called once per frame

    void SpawnTrash(int numberOfTrashSpawned)
    {
        int ranIdx;
        for(int i = 0; i < numberOfTrashSpawned; i++)
        {
            do
            {
                ranIdx = Random.Range(1, spawnCount);
            }
            while (IsThatPlaceTaken(ranIdx));

            Instantiate(trash, spawnPosition[ranIdx].transform.position, Quaternion.identity, spawnPosition[ranIdx]);
            spawnLocNote[ranIdx] = 1;
            currSpawned++;
        }
    }

    bool IsThatPlaceTaken(int idx)
    {
        if (spawnLocNote[idx] > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DecreaseSpawnedGarbage(Transform transform)
    {
        currSpawned--;
        for(int i = 0; i < spawnPosition.Length; i++)
        {
            if (spawnPosition[i].position == transform.position)
            {
                spawnLocNote[i] = 0;
            }
        }
        SpawnTrash(1);
    }
}
