using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject menuContainer;
    [SerializeField] GameObject settingContainer;
    [SerializeField] GameObject MapSelectionUpgrade;


    public void EnableSettingContainer()
    {
        menuContainer.SetActive(false);
        settingContainer.SetActive(true);
        MapSelectionUpgrade.SetActive(false);
    }

    public void EnableMainMenuContainer()
    {
        menuContainer.SetActive(true);
        settingContainer.SetActive(false);
        MapSelectionUpgrade.SetActive(false);
    }

    public void EnableMapSelection()
    {
        menuContainer.SetActive(false);
        MapSelectionUpgrade.SetActive(true);
    }
}
