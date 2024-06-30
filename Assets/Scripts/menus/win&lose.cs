/*
 * Author: Javier Chen Yuhong
 * Date: 30/06/2024
 * Description: 
 * Contains functions related to the win/lose menu.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winlose : SharedMenu
{
    /// <summary>
    /// Index of the main menu scene.
    /// </summary>
    public int mainMenuIndex = 0;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// Locks the cursor to the center of the screen and makes it visible.
    /// </summary>
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Returns the player to the main menu.
    /// Unlocks the mouse cursor, restarts the game, and navigates to the main menu scene.
    /// </summary>
    public void backtostart()
    {
        UnlockMouse(); // Call to unlock the mouse cursor
        GameManager.instance.RestartGame(); // Call to restart the game state
        GameManager.instance.GoToScene(mainMenuIndex); // Navigate to the main menu scene
    }
}
