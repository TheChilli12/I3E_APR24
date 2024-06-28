/*
 * Author: Javier Chen Yuhong
 * Date: 20/06/2024
 * Description: 
 * Contains functions related to the Pause menu.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winlose: SharedMenu
{
    public int mainMenuIndex = 0;
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void backtostart()
    {
        UnlockMouse();
        GameManager.instance.GoToScene(mainMenuIndex);
    }
}
