using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUpgradeTransition : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    

    public void TriggerMap()
    {
        anim.SetTrigger("TriggerMap");
    }

    public void TriggerUpgrades()
    {
        anim.SetTrigger("TriggerUpgrades");
    }
}
