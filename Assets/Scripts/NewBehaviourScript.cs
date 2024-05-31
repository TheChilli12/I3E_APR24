using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManager;
public class SceneChanger : MonoBehaviour
{
    public int targetSceneIndex;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player");
    }

    // Update is called once per frame
    void ChangeScene()
    {
        SceneManager.LoadScene();
    }
}
