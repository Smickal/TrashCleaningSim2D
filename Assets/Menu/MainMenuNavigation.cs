using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject menuContainer;
    [SerializeField] GameObject settingContainer;
    [SerializeField] GameObject MapSelectionUpgrade;

    [Header("Animator")]
    [SerializeField] Animator menuAnim;
    [SerializeField] Animator MapSelectionAnim;

    private void Start()
    {
        FindObjectOfType<CarSpawner>().SpawnTrafficCar();
    }



    public void EnableSettingContainer()
    {
        menuContainer.SetActive(false);
        settingContainer.SetActive(true);
    }

    public void EnableMenuFromSetting()
    {
        menuContainer.SetActive(true);
        settingContainer.SetActive(false);
    }

    public void EnableMainMenuContainer()
    {
        menuAnim.SetTrigger("TriggerMenu");
        MapSelectionAnim.SetTrigger("TriggerMenu");
    }

    public void EnableMapSelection()
    {
        menuAnim.SetTrigger("TriggerPlay");
        MapSelectionAnim.SetTrigger("TriggerPlay");
    }
}
