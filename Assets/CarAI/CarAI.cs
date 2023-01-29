using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class CarAI : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] float rayCarRange = 1f;
    [SerializeField] Transform careye; 
    [SerializeField] LayerMask carAILayer;
    [SerializeField] LayerMask playerLayerMask;
    WaypointManager waypointManager;
    Waypoint startingPos;
    Waypoint currPos;
    Waypoint nextTarget;

    int idx = 0;
    bool move = true;
    bool isFacingTargetFirstTime = false;
    public bool Move { get { return move; } set { move = value; } }

    float targetAngle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Movement>().TriggerPopOutRepair();
            FindObjectOfType<AudioManager>().PlaySound("CarCrash");
            Debug.Log("HIT PLAYER");
        }

    }


    private void Awake()
    {
        waypointManager = FindObjectOfType<WaypointManager>();
        startingPos = waypointManager.GenerateStartingPosition();

        transform.position = startingPos.transform.position;
        currPos = startingPos;

        SetNextTarget();
    }

    private void Start()
    {      
        SnapToTarget();
    }

    private void Update()
    {
        if (!DetectCarInfront() && isFacingTargetFirstTime)
        {
            ProcessMovement();
        }
        RotateToTarget();

    }

    private bool DetectCarInfront()
    {
        Vector3 dir = nextTarget.transform.position - transform.position;
        //RaycastHit2D hit = Physics2D.Raycast(careye.position, dir, rayCarRange, carAILayer);
        RaycastHit2D hit = Physics2D.BoxCast(careye.transform.position, new Vector2(1f, 0.5f), 0f, transform.up, rayCarRange, carAILayer);
       // Debug.DrawRay(careye.position, dir);
        //Debug.Log(hit.collider);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(careye.position, new Vector3(2f,1f,0f));
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
        if (distance <= 0.25f)
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
