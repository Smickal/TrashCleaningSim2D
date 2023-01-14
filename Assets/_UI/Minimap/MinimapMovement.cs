using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform Player;
    [SerializeField] float zoomPower = 2f;
    [SerializeField] float zoomSpeed = 5f;
    Camera minimapCamera;

    float maxZoom;
    float curZoom;
    private void Awake()
    {
        minimapCamera = GetComponent<Camera>();
    }


    private void Start()
    {
        curZoom = minimapCamera.orthographicSize;
        maxZoom = minimapCamera.orthographicSize + zoomPower;
    }

    

    private void LateUpdate()
    {
        Vector3 newPos = Player.position;
        newPos.z = transform.position.z;
        transform.position = newPos;
        ProcessCameraZoomOut();
    }

    void ProcessCameraZoomOut()
    {
        Movement movement = Player.GetComponent<Movement>();
        bool isMoving = movement.IsCarMoving();
        if (isMoving)
        {
            minimapCamera.orthographicSize += Time.deltaTime * zoomSpeed;
        }
        else
        {
            minimapCamera.orthographicSize -= Time.deltaTime * zoomSpeed; 
        }
        minimapCamera.orthographicSize = Mathf.Clamp(minimapCamera.orthographicSize, curZoom, maxZoom);
    }


}
