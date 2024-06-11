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

public class MainMenu : MonoBehaviour
{
    public GameObject helpMenu;
    public GameObject mainMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void HelpGame()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }
    public void QuitGame()
    {
        Debug.Log("Player has quit");
        Application.Quit();
    }
}
