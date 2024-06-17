/*
 * Author: Javier Chen Yuhong
 * Date: 13/06/2024
 * Description: 
 * Contains functions related to the Pause menu.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : SharedMenu
{
    public GameObject pauseContent;
    public static bool isPaused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        UnlockMouse();
        mainMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        LockMouse();
        mainMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public override void ExitGame()
    {
        Time.timeScale = 1f;
        ResumeGame();
        UnlockMouse();
        SceneManager.LoadScene(0);
    }

    public override void backbutton()
    {
        currentPage.SetActive(false);
        pauseContent.SetActive(true);
    }

    public virtual void HelpGame()
    {
        helpMenu.SetActive(true);
        currentPage = helpMenu;
        pauseContent.SetActive(false);
    }
}
