/*
 * Author: Javier Chen Yuhong
 * Date: 06/06/2024
 * Description: 
 * Teleporter that will be used to change scenes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public int targetSceneIndex;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeScene();
        }
    }

    // Update is called once per frame
    void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }


}
