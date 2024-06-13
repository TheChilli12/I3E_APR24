/*
 * Author: Javier Chen Yuhong
 * Date: 06/06/2024
 * Description: 
 * Main menu functions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : SharedMenu
{
    public GameObject creditsMenu;
    public void PlayGame()
    {
        LockMouse();
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void CreditsGame()
    {
        creditsMenu.SetActive(true);
        currentPage = creditsMenu;
        mainMenu.SetActive(false);
    }
}
