using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public int currentScene;
    private void Awake()
    {
        // currentScene = SceneManager.GetActiveScene().buildIndex;
        // Debug.Log(currentScene);
        // if(currentScene != 0) 
        // {
        DontDestroyOnLoad(gameObject);
        // }
    }
}
