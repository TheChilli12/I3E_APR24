/*
 * Author: Javier Chen Yuhong
 * Date: 06/06/2024
 * Description: 
 * Start button for the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : SharedMenu
{
    public GameObject pauseContent;
    public static bool isPaused;
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
    void Start()
    {
        mainMenu.SetActive(false);
        isPaused = false;
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
