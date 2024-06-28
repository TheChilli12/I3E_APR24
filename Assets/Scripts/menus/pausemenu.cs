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

public class PauseMenu : SharedMenu
{
    public int restartindex;
    public int mainMenuIndex = 0;
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
                if(GameManager.instance.currentHealth > 0)
                {
                    PauseGame();
                }
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

    public void backtostart()
    {
        Time.timeScale = 1f;
        ResumeGame();
        UnlockMouse();
        GameManager.instance.GoToScene(mainMenuIndex);
    }

    public void HelpGame()
    {
        helpMenu.SetActive(true);
        currentPage = helpMenu;
        pauseContent.SetActive(false);
    }

    public void Restart()
    {
        LockMouse();
        mainMenu.SetActive(false);
        Time.timeScale = 1f;
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
