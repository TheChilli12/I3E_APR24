using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedMenu : MonoBehaviour
{
    public GameObject helpMenu;
    public GameObject mainMenu;
    [SerializeField]
    public GameObject currentPage;
    public virtual void backbutton()
    {
        currentPage.SetActive(false);
        mainMenu.SetActive(true);
    }

    public virtual void HelpGame()
    {
        helpMenu.SetActive(true);
        currentPage = helpMenu;
        mainMenu.SetActive(false);
    }

    public virtual void ExitGame()
    {
        Debug.Log("Player has quit");
        Application.Quit();
    }

    public void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
