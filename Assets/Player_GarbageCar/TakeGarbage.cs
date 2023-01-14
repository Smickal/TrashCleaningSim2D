using JetBrains.Annotations;
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


    [Header("$")]
    [SerializeField] int trashMoneyValue = 5;
    [SerializeField] int extraBonusDump = 10;

    [Header("Initialization")]
    [SerializeField] GameObject takinIndicator;
    [SerializeField] Image fillImage;
    [SerializeField] Button takeTrashButton;
    [SerializeField] Button dumpTrashButton;
    [SerializeField] GameObject UI_Control;
    [SerializeField] GameObject UI_MiniGame;
    [SerializeField] LayerMask garbageLayer;
    [SerializeField] LayerMask trashStationLayer;
    [SerializeField] SpawnTrashSnap sts;

    [Header("Animator")]
    [SerializeField] Animator minigameAnimator;

    GarbageCounter garbageCounter;
    EconomySystem economySystem;
    float curPressTime = 0f;

    [SerializeField ]int currentDump;
    int garbageInserted = 0;


    private void Awake()
    {
        garbageCounter = FindObjectOfType<GarbageCounter>();
        economySystem = FindObjectOfType<EconomySystem>();
    }


    void Start()
    {
        garbageCounter.StartUp(maxDump);
        fillImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            ProccessInput();
        }
        CheckTrash();
        CheckDump();
        TakeTrash();
    }

    private bool CheckDump()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, collectRange, trashStationLayer);
        if (col != null && currentDump > 0)
        {
            dumpTrashButton.gameObject.SetActive(true);
            return true;
        }
        else
        {
            dumpTrashButton.gameObject.SetActive(false);
            return false;
        }
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
            takeTrashButton.gameObject.SetActive(true);
            return true;
        }
        else
        {
            takeTrashButton.gameObject.SetActive(false);
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
            economySystem.AddMoney(trashMoneyValue);
            garbageCounter.UpdateText(currentDump);
            curPressTime = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, collectRange);
    }


    public void DumpAllTrash()
    {
        //dump trash
        int totalDumped = currentDump;
        currentDump = 0;
        //add extra money
        int extraBonus = totalDumped * extraBonusDump;
        economySystem.AddMoney(extraBonus);
        //update text
        garbageCounter.UpdateText(currentDump);
    }


    public int GetCurrentDump()
    {
        return currentDump;
    }


    public void ActivateMiniGame()
    {
        //Disable control UI
        //activate minigame
        UI_Control.SetActive(false);
        UI_MiniGame.SetActive(true);

        minigameAnimator.SetTrigger("Enter");

        sts.SpawnTrash();

    }

    public void DeactivateMiniGame()
    {


        StartCoroutine(DectivateMiniGem());

    }

    IEnumerator DectivateMiniGem()
    {
        minigameAnimator.SetTrigger("Exit");

        yield return new WaitForSeconds(0.25f);
        UI_Control.SetActive(true);

        UI_MiniGame.SetActive(false);
    }

    public void CheckGarbageCounted()
    {
        if(garbageInserted == currentDump)
        {
            DeactivateMiniGame();

            garbageInserted = 0;
            DumpAllTrash();
        }
    }

    public void IncreaseGarbageCounted()
    {
        garbageInserted++;
        CheckGarbageCounted();
    }

    public int GetMaxCapacity()
    {
        return maxDump;
    }

    public float GetCollectRate()
    {
        return maxPressTime;
    }

    public void SetMaxCapacityAndRate(int maxCapacity, float colRate)
    {
        maxDump = maxCapacity;
        maxPressTime = colRate;
    }    
}
