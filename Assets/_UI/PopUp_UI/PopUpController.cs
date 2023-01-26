using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator popUpAnimator;
    [SerializeField] GameObject popUpPrefab;
    [SerializeField] float fadeTime = 0.2f;

    private void Start()
    {
        DisableContainer();
    }


    public void TriggerFadeOut()
    {
        popUpAnimator.SetTrigger("CancelClicked");
    }

    public void TriggerFadeIn()
    {           
        popUpPrefab.SetActive(true);
        popUpAnimator.SetTrigger("TriggerPop");
        FindObjectOfType<AudioManager>().PlaySound("Alert");
    }


    public void DisableContainer()
    {
        popUpPrefab.SetActive(false);
    }
}
