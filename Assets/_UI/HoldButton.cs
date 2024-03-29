using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public UnityEvent unityEventDown;
    public UnityEvent unityEventUp;

    [SerializeField] string sfxString = "SortTrash";
    bool isPressed = false;

    private void OnEnable()
    {
        isPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {       
        isPressed = true;
        FindObjectOfType<AudioManager>().PlaySound(sfxString);
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
        }
        else
        {
            unityEventUp.Invoke();
        }
    }
}
