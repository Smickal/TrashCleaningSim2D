using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasStation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform spawnPoint;
    public Transform SpawnPoint { get { return spawnPoint; } }
}
