using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuNavigation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject menuContainer;
    [SerializeField] GameObject settingContainer;
    


    public void EnableSettingContainer()
    {
        menuContainer.SetActive(false);
        settingContainer.SetActive(true);
    }

    public void EnableMainMenuContainer()
    {
        menuContainer.SetActive(true);
        settingContainer.SetActive(false);
    }
}
