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
    public GameObject settingsMenu;

    public void PlayGame()
    {
        AudioSource.PlayClipAtPoint(clickAudio, transform.position, 1f);
        LockMouse();
        Time.timeScale = 1f;
        GameManager.instance.GoToScene(1);
    }

    public void CreditsGame()
    {
        AudioSource.PlayClipAtPoint(clickAudio, transform.position, 1f);
        creditsMenu.SetActive(true);
        currentPage = creditsMenu;
        mainMenu.SetActive(false);
    }

    public virtual void SettingsGame()
    {
        AudioSource.PlayClipAtPoint(clickAudio, transform.position, 1f);
        settingsMenu.SetActive(true);
        currentPage = settingsMenu;
        mainMenu.SetActive(false);
    }
}
