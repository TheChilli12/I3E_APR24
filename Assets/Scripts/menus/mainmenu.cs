/*
 * Author: Javier Chen Yuhong
 * Date: 20/06/2024
 * Description: 
 * Contains functions related to the Main menu.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : SharedMenu
{

    public GameObject creditsMenu;
    public GameObject settingsMenu;
    public AudioMixer BGM;
    
    public void PlayGame()
    {
        LockMouse();
        Time.timeScale = 1f;
        GameManager.instance.GoToScene(1);
    }

    public void CreditsGame()
    {
        creditsMenu.SetActive(true);
        currentPage = creditsMenu;
        mainMenu.SetActive(false);
    }

    /// <summary>
    /// Displays the help menu and hides the main menu.
    /// Sets the current page to the help menu.
    /// </summary>
    public virtual void HelpGame()
    {
        helpMenu.SetActive(true);
        currentPage = helpMenu;
        mainMenu.SetActive(false);
    }

    public void ToggleBGM(bool toggleValue)
    {
        if (toggleValue == true)
        {
            BGM.SetFloat("BGMtoggle",0f);
        }
        else
        {
            BGM.SetFloat("BGMtoggle",-80f);
        }
        Debug.Log(toggleValue);
    }

    public virtual void SettingsGame()
    {
        settingsMenu.SetActive(true);
        currentPage = settingsMenu;
        mainMenu.SetActive(false);
    }

    /// <summary>
    /// Quits the application.
    /// Logs a debug message indicating that the player has quit.
    /// </summary>
    public virtual void ExitGame()
    {
        Debug.Log("Player has quit");
        Application.Quit();
    }
}
