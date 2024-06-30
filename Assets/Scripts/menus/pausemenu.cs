/*
 * Author: Javier Chen Yuhong
 * Date: 30/06/2024
 * Description: 
 * Contains functions related to the Pause menu.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : SharedMenu
{
    /// <summary>
    /// The index of the scene to restart from.
    /// </summary>
    public int restartindex;

    /// <summary>
    /// The index of the main menu scene.
    /// </summary>
    public int mainMenuIndex = 0;

    /// <summary>
    /// The GameObject representing the pause menu content.
    /// </summary>
    public GameObject pauseContent;

    /// <summary>
    /// Indicates whether the game is currently paused.
    /// </summary>
    public static bool isPaused = false;

    /// <summary>
    /// Checks for the pause key input and toggles pause/resume game states.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                if (GameManager.instance.currentHealth > 0)
                {
                    PauseGame();
                }
            }
        }
    }

    /// <summary>
    /// Pauses the game, unlocks the mouse cursor, and displays the pause menu.
    /// </summary>
    public void PauseGame()
    {
        // Call to unlock the mouse cursor
        UnlockMouse();
        // Activate the pause menu content
        pauseContent.SetActive(true); 
        // Stop time to pause the game
        Time.timeScale = 0f; 
        // Set the game state to paused
        isPaused = true; 
    }

    /// <summary>
    /// Resumes the game, locks the mouse cursor, and hides the pause menu.
    /// </summary>
    public void ResumeGame()
    {
        // Call to lock the mouse cursor
        LockMouse(); 
        // Deactivate the pause menu content
        pauseContent.SetActive(false); 
        // Resume normal time flow
        Time.timeScale = 1f; 
        // Set the game state to resumed
        isPaused = false; 
    }

    /// <summary>
    /// Returns to the main menu, resumes game time, and unlocks the mouse cursor.
    /// </summary>
    public void backtostart()
    {
        // Resume game time
        Time.timeScale = 1f; 
        // Call to resume game state
        ResumeGame(); 
        // Call to unlock the mouse cursor
        UnlockMouse(); 
        // Call to restart the game state
        GameManager.instance.RestartGame(); 
        // Navigate to the main menu scene
        GameManager.instance.GoToScene(mainMenuIndex); 
    }

    /// <summary>
    /// Restarts the game from the specified restart index, resetting player stats and scene state.
    /// </summary>
    public void Restart()
    {
        // Call to lock the mouse cursor
        LockMouse(); 
        // Deactivate the pause menu content
        pauseContent.SetActive(false); 
        // Resume normal time flow
        Time.timeScale = 1f; 

        // Check the restart index and perform appropriate game restart actions
        if (restartindex == 1)
        {
            GameManager.instance.RestartGamelvl0();
            GameManager.instance.GoToScene(restartindex);
        }
        else if (restartindex == 2)
        {
            GameManager.instance.RestartGamelvl1();
            GameManager.instance.GoToScene(restartindex);
        }
        else if (restartindex == 3)
        {
            GameManager.instance.RestartGamelvl2();
            GameManager.instance.GoToScene(restartindex);
        }
    }
}
