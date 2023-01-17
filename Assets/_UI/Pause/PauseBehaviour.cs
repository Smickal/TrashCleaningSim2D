using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pause;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject settingPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
    }

    public void SettingPressed()
    {
        pausePanel.SetActive(false);
        settingPanel.SetActive(true);
    }


    public void BackFromSetting()
    {
        pausePanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
