using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    bool isMouseEnter = false;
    bool isMousePressed = false;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseEnter)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isMousePressed = true;
            }
        }


        if(Input.GetKey(KeyCode.Mouse0) && isMousePressed)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            newPos = new Vector3(newPos.x, newPos.y, 0f);
            transform.position = newPos;
        }

        if(Input.GetMouseButtonUp(0))
        {
            ResetPosition();
        }

        //Debug.Log(isMouseEnter + " "+isMousePressed);
    }

    public void ResetPosition()
    {
        isMouseEnter = false;
        isMousePressed = false;
        transform.localPosition = Vector2.zero;
    }

    private void OnMouseEnter()
    {
        isMouseEnter = true;
    }

    private void OnMouseExit()
    {
        isMouseEnter = false;
    }

}
