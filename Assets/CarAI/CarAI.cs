using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CarAI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] float rayCarRange = 1f;
    [SerializeField] LayerMask carAILayer;
    [SerializeField] BoxCollider2D carCollider;
    [SerializeField] Transform careye; 
    WaypointManager waypointManager;
    Waypoint startingPos;
    Waypoint currPos;
    Waypoint nextTarget;

    int idx = 0;
    bool move = true;
    bool isFacingTargetFirstTime = false;
    public bool Move { get { return move; } set { move = value; } }

    float targetAngle;
    private void Awake()
    {
        waypointManager = FindObjectOfType<WaypointManager>();
        startingPos = waypointManager.GenerateStartingPosition();

        transform.position = startingPos.transform.position;
        currPos = startingPos;
    }

    private void Start()
    {
        Invoke("SetNextTarget",0.5f);
        SetNextTarget();
        SnapToTarget();
    }

    private void Update()
    {
        RotateToTarget();
        if (!DetectCarInfront() && isFacingTargetFirstTime)
        {
            ProcessMovement();
        }

    }

    private bool DetectCarInfront()
    {
        Vector3 dir = nextTarget.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(careye.position, dir, rayCarRange, carAILayer);
        Debug.DrawRay(careye.position, dir);
        if (hit.collider != null)
        {
            return true;
        }

        else
        {
            return false;
        }
    }


    void RotateToTarget()
    {
        Vector3 dir = nextTarget.transform.position - transform.position; 
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
    }

    void SnapToTarget()
    {
        Vector2 dir = nextTarget.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        targetAngle = angle;
        StartCoroutine(StartMoving());
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(0.1f);
        isFacingTargetFirstTime = true;
    }


    private void ProcessMovement()
    {
        if (!move) return;
        float distance = Vector2.Distance(nextTarget.transform.position, transform.position);
        if (distance <= 0.1f)
        {
            //update new target
            currPos = nextTarget;
            SetNextTarget();
        }
        else
        {
            //moveTowardsTarget
            Vector3 direction = (nextTarget.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

        }
    }

    private void SetNextTarget()
    {
        int nextIndex = Random.Range(0, currPos.nextWaypoint.Length);

        for(int i = 0; i < currPos.nextWaypoint.Length; i++)
        {
            if(i == nextIndex)
            {
                nextTarget = currPos.nextWaypoint[i].GetComponent<Waypoint>();
            }
        }
    }


    
}
