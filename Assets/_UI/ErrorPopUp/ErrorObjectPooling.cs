using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ErrorObjectPooling : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject objPool;

    [Header("Effect")]
    [SerializeField] float disableTime = 2f;
    [SerializeField] int poolSize;

    [Header("ErrorText")]
    [TextArea(2,7)][SerializeField] string textValue;
    TextMeshProUGUI textDisplay;

    List<GameObject> pool = new List<GameObject>();
    private void Awake()
    {
        textDisplay = objPool.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        CreateObjPool();
        ChangeTextToPool();
    }

    private void ChangeTextToPool()
    {
        foreach(GameObject obj in pool)
        {
            TextMeshProUGUI textDisplay = obj.GetComponentInChildren<TextMeshProUGUI>();
            textDisplay.text = textValue;
        }
    }

    private void CreateObjPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            GameObject newObj = Instantiate(objPool, transform);
            newObj.SetActive(false);
            pool.Add(newObj);
        }
    }

    // Update is called once per frame
    
    public void TriggerError()
    {
        //Get 1 in-active obj
        foreach(GameObject obj in pool)
        {
            if(!obj.activeInHierarchy)
            {
                //set active for 2 seconds
                //disables the obj
                StartCoroutine(ActivateObject(obj));
                break;
            }
        }
    }

    IEnumerator ActivateObject(GameObject obj)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(disableTime);

        obj.SetActive(false);
    }
}
