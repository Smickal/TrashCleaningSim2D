using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scrollbar;
    float scrollPos = 0;
    float[] pos;

    int posisi = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for(int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
                }

            }
        }

    }

    public void Next()
    {
        if(posisi < pos.Length - 1)
        {
            posisi++;
            scrollPos = pos[posisi];
        }
    }

    public void Prev()
    {
        if (posisi > 0)
        {
            posisi--;
            scrollPos = pos[posisi];
        }
    }
}
