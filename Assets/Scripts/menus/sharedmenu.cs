/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
 * Description: 
 * Contains functions related to both menus.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedMenu : MonoBehaviour
{
    /// <summary>
    /// The GameObject representing the help menu.
    /// </summary>
    public GameObject helpMenu;

    /// <summary>
    /// The GameObject representing the main menu.
    /// </summary>
    public GameObject mainMenu;

    /// <summary>
    /// The currently active menu page.
    /// </summary>
    [SerializeField]
    public GameObject currentPage;

    /// <summary>
    /// The AudioClip played upon button click.
    /// </summary>
    [SerializeField]
    public AudioClip clickAudio;

    /// <summary>
    /// Handles the action when the back button is pressed.
    /// Logs a debug message, hides the current page, and shows the main menu.
    /// </summary>
    public virtual void backbutton()
    {
        Debug.Log("AudioPlayed");
        currentPage.SetActive(false);
        mainMenu.SetActive(true);
    }

    /// <summary>
    /// Unlocks the mouse cursor and makes it visible.
    /// </summary>
    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// Locks the mouse cursor and hides it.
    /// </summary>
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}