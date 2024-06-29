/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
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
    /// <summary>
    /// The GameObject representing the credits menu.
    /// </summary>
    public GameObject creditsMenu;

    /// <summary>
    /// The GameObject representing the settings menu.
    /// </summary>
    public GameObject settingsMenu;

    /// <summary>
    /// The audio mixer for the background music (BGM).
    /// </summary>
    public AudioMixer BGM;

    /// <summary>
    /// Starts the game by locking the mouse, setting the time scale to normal, and loading the first scene.
    /// </summary>
    public void PlayGame()
    {
        // Lock the mouse cursor
        LockMouse();
        
        // Set the time scale to normal speed
        Time.timeScale = 1f;
        
        // Load the first scene
        GameManager.instance.GoToScene(1);
    }

    /// <summary>
    /// Displays the credits menu and hides the main menu.
    /// </summary>
    public void CreditsGame()
    {
        // Activate the credits menu
        creditsMenu.SetActive(true);
        
        // Set the current page to the credits menu
        currentPage = creditsMenu;
        
        // Deactivate the main menu
        mainMenu.SetActive(false);
    }

    /// <summary>
    /// Displays the help menu and hides the main menu.
    /// Sets the current page to the help menu.
    /// </summary>
    public virtual void HelpGame()
    {
        // Activate the help menu
        helpMenu.SetActive(true);
        
        // Set the current page to the help menu
        currentPage = helpMenu;
        
        // Deactivate the main menu
        mainMenu.SetActive(false);
    }

    /// <summary>
    /// Toggles the background music (BGM) on or off.
    /// </summary>
    /// <param name="toggleValue">True to turn on the BGM, false to turn it off.</param>
    public void ToggleBGM(bool toggleValue)
    {
        // If toggleValue is true, set BGM volume to 0 (on)
        if (toggleValue == true)
        {
            BGM.SetFloat("BGMtoggle", 0f);
        }
        // If toggleValue is false, set BGM volume to -80 (off)
        else
        {
            BGM.SetFloat("BGMtoggle", -80f);
        }
        
        // Log the current toggle value for debugging
        Debug.Log(toggleValue);
    }

    /// <summary>
    /// Displays the settings menu and hides the main menu.
    /// Sets the current page to the settings menu.
    /// </summary>
    public virtual void SettingsGame()
    {
        // Activate the settings menu
        settingsMenu.SetActive(true);
        
        // Set the current page to the settings menu
        currentPage = settingsMenu;
        
        // Deactivate the main menu
        mainMenu.SetActive(false);
    }

    /// <summary>
    /// Quits the application.
    /// Logs a debug message indicating that the player has quit.
    /// </summary>
    public virtual void ExitGame()
    {
        // Log the exit action for debugging
        Debug.Log("Player has quit");
        
        // Quit the application
        Application.Quit();
    }
}