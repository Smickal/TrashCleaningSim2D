using Mono.Cecil.Cil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;


    [Header("Initialization")]
    [SerializeField] PopUpController repairController;



    Rigidbody2D rb;
    FuelSystem fuelSystem;
    GameManager gameManager;
    EconomySystem economySystem;

    bool isMoving = false;
    bool isFuelEmpty = false;

    float verticalAxis;
    float horizontalAxis;

    bool isUpPressed, isDownPressed;
    bool isleftPressed, isrightPressed;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        economySystem = FindObjectOfType<EconomySystem>();

        rb = GetComponent<Rigidbody2D>();
        fuelSystem = GetComponent<FuelSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        GetKeyBoardMovement();
       // GetButtonVerticalMovement();
       // GetButtonHorizontalMovement();

        if(!isFuelEmpty)
        {
            ProcessMovement();
        }
        ProcessFuelSystem();

    }

    


    private void GetKeyBoardMovement()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        this.verticalAxis = verticalAxis;
        this.horizontalAxis = horizontalAxis;
    }
    private void GetButtonHorizontalMovement()
    {
        if (isleftPressed && !isrightPressed)
        {
            horizontalAxis -= Time.deltaTime;
        }
        else if (isrightPressed && !isleftPressed)
        {
            horizontalAxis += Time.deltaTime;
        }
        else
        {
            horizontalAxis = 0f;
        }

        horizontalAxis = Mathf.Clamp(horizontalAxis, -1f, 1f);
    }


    private void GetButtonVerticalMovement()
    {
        if (isUpPressed && !isDownPressed)
        {
            verticalAxis += Time.deltaTime;
        }
        else if (isDownPressed && !isUpPressed)
        {
            verticalAxis -= Time.deltaTime;
        }
        else
        {
            verticalAxis = 0f;
        }

        verticalAxis = Mathf.Clamp(verticalAxis, -1f, 1f);
    }

    private void ProcessMovement()
    {
        

        float yAxisMovement = this.verticalAxis * speed * Time.deltaTime;
        float rotationAxis = rotationSpeed * Time.deltaTime * this.horizontalAxis;

        transform.Translate(0f, yAxisMovement, 0f);
        transform.Rotate(Vector3.forward * -rotationAxis);

        CheckIfCarMoving(yAxisMovement);
    }


    public void TeleportToTheNearestRepairStation()
    {
        int totalDerekValue = gameManager.GetRepairCost();

        if (!economySystem.IsMoneyEnough(totalDerekValue))
        {
            return;
        }
        fuelSystem.RefillFuel(totalDerekValue);


        GameObject[] repairStations = GameObject.FindGameObjectsWithTag("Repair Station");
        GameObject closestRepairStations = repairStations[0];

        foreach (GameObject gasStation in repairStations)
        {
            if (Vector2.Distance(closestRepairStations.transform.position, transform.position) >
                Vector2.Distance(gasStation.transform.position, transform.position))
            {
                closestRepairStations = gasStation;
            }
        }

        transform.position = closestRepairStations.GetComponent<RepairStation>().SpawnPoint.position;
        transform.rotation = closestRepairStations.GetComponent<RepairStation>().SpawnPoint.rotation;

        repairController.TriggerFadeOut();
    }

    void CheckIfCarMoving(float movementValue)
    {
        if (movementValue != 0f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void ProcessFuelSystem()
    {
        if(isMoving)
        {
            fuelSystem.DecreaseFuel();
        }
    }

    public bool IsCarMoving()
    {
        return isMoving;
    }


    public void ForwardPressed()
    {
        isUpPressed = true;
    }

    public void ForwardUnpressed()
    {
        isUpPressed = false;
    }

    public void DownPressed()
    {
        isDownPressed = true;
    }

    public void DownUnpressed()
    {
        isDownPressed = false;
    }

    public void LeftPressed()
    {
        isleftPressed = true;
    }

    public void LeftUnpressed()
    {
        isleftPressed=false;
    }

    public void RightPressed()
    {
        isrightPressed = true;
    }

    public void RightUnpressed()
    {
        isrightPressed = false;
    }

    
    public void IsFuelEmpty(bool value)
    {
        isFuelEmpty = value;
    }


    public void TriggerPopOutRepair()
    {
        repairController.TriggerFadeIn();
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
