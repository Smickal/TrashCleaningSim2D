using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    [SerializeField] TextMeshProUGUI dayText;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void ResetCurrentDay()
    {
        animator.SetTrigger("FadeIn");
    }

    public void StartDay(int value)
    {
        dayText.text = $"Day {value}";
        animator.SetTrigger("FadeOut");

    }
}
