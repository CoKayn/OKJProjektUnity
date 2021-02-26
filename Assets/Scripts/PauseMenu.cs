using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject pauseMenuUi;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }    
    }
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        menu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        EventSystem.current.SetSelectedGameObject(player);
    }
    void Pause()
    {
        EventSystem.current.SetSelectedGameObject(menu);
        menu.SetActive(true);
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadSettings()
    {     
        pauseMenuUi.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }   
}
