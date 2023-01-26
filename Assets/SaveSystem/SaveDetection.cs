using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDetection : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject newGamebutton;
    [SerializeField] PopUpController popUpController;

    SaveSystem saveSystem;

    private void Awake()
    {
        saveSystem = FindObjectOfType<SaveSystem>(); 
    }

    private void Start()
    {
        CheckSaveFiles();
    }
    public void CheckSaveFiles()
    {
        Button newgameBtn = newGamebutton.GetComponent<Button>();
        if (saveSystem.CheckFileExist())
        {
            continueButton.SetActive(true);
            newgameBtn.onClick.AddListener(popUpController.TriggerFadeIn);
        }
        else
        {
            continueButton.SetActive(false);

            newgameBtn.onClick.AddListener(() =>
            {
                FindObjectOfType<MainMenuNavigation>().EnableMapSelection();
                saveSystem.CreateNewSave();
            });
        }
    }
    
}
