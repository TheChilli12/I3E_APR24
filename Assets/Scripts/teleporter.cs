/*
 * Author: Javier Chen Yuhong
 * Date: 20/06/2024
 * Description: 
 * Teleporter that will be used to change scenes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// The scene index the teleporter transports the player to
    /// </summary>
    public int targetSceneIndex;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        ///Checks if collision is with player
        if (other.gameObject.tag == "Player")
        {
            ///calls change scene function
            ChangeScene();
        }
    }

    // Update is called once per frame
    void ChangeScene()
    {
        ///load the scene by their index in the build
        SceneManager.LoadScene(targetSceneIndex);
    }
}
