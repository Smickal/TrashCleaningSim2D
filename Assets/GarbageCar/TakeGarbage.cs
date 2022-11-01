using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TakeGarbage : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int maxDump = 10;
    [SerializeField] float collectRange = 1f;
    [SerializeField] float maxPressTime = 2f;

    [Header("LayerMask")]
    [SerializeField] LayerMask garbageLayer;

    [Header("Initialization")]
    [SerializeField] GameObject takinIndicator;
    [SerializeField] Image fillImage;

    GarbageCounter garbageCounter;
    float curPressTime = 0f;
    int currentDump;

    private void Awake()
    {
        garbageCounter = FindObjectOfType<GarbageCounter>();
    }


    void Start()
    {
        garbageCounter.StartUp(maxDump);
        fillImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.T))
        {
            ProccessInput();
        }
        TakeTrash();
    }

    public void ProccessInput()
    {
        if(CheckTrash() && currentDump < maxDump)
        {
            curPressTime += Time.deltaTime;
            fillImage.fillAmount = curPressTime / maxPressTime;
        }
        else
        {
            Reset();
        }

    }

    public void Reset()
    {
        curPressTime = 0f;
        fillImage.fillAmount = curPressTime;
    }

    private bool CheckTrash()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, collectRange, garbageLayer);
        if(col != null)
        {
            takinIndicator.transform.position = col.transform.position;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void TakeTrash()
    {
        if (curPressTime >= maxPressTime)
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, collectRange, garbageLayer);
            col.GetComponent<Garbage>().TakeTrash();
            currentDump++;
            garbageCounter.UpdateText(currentDump);
            curPressTime = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, collectRange);
    }

}
