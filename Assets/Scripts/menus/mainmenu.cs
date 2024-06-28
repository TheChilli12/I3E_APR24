/*
 * Author: Javier Chen Yuhong
 * Date: 06/06/2024
 * Description: 
 * Main menu functions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : SharedMenu
{
    public GameObject creditsMenu;
    public GameObject settingsMenu;

    public AudioMixer BGM;

    public void PlayGame()
    {
        AudioSource.PlayClipAtPoint(clickAudio, transform.position, 1f);
        LockMouse();
        Time.timeScale = 1f;
        GameManager.instance.GoToScene(1);
    }
    public void HelpGame()
    {
        AudioSource.PlayClipAtPoint(clickAudio, transform.position, 1f);
        helpMenu.SetActive(true);
        currentPage = helpMenu;
        mainMenu.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Player has quit");
        Application.Quit();
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

    public void ToggleBGM(bool toggleValue)
    {
        if (toggleValue == true)
        {
            BGM.SetFloat("BGMtoggle",0f);
        }
        else
        {
            BGM.SetFloat("BGMtoggle",-80f);
        }
        Debug.Log(toggleValue);
    }
}
