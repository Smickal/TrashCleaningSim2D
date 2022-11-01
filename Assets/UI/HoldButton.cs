using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public UnityEvent unityEventDown;
    public UnityEvent unityEventUp;

    bool isPressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {       
        isPressed = true;        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        
    }

    private void Update()
    {
        if(isPressed)
        {
            unityEventDown.Invoke();
            Debug.Log("pressed");
        }
        else
        {
            unityEventUp.Invoke();
            Debug.Log("un-pressed");
        }
    }
}
