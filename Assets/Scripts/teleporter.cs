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
public class SceneChanger : Interactable
{
    [SerializeField]
    public bool lockedbyMedkit;
    public int lockedbyCollectible = 0;
    /// <summary>
    /// The scene index the teleporter transports the player to
    /// </summary>
    public int targetSceneIndex;

    [SerializeField]
    public Material lockedMaterial;

    [SerializeField]
    public Material unlockedMaterial;

    public GameObject door;
    private Renderer doorRenderer;

    private void Start()
    {
        if (door != null)
        {
            doorRenderer = door.GetComponent<Renderer>();
        }
    }

    public void Update()
    {
        if (doorRenderer != null)
        {
            if (lockedbyMedkit == true || lockedbyCollectible > GameManager.instance.collectibleCount)
            {
                doorRenderer.material = lockedMaterial;
            }
            else
            {
                doorRenderer.material = unlockedMaterial;
            }
        }
    }

    public override void Interact(Player thePlayer)
    {
        if (lockedbyMedkit == true)
        {
            GameManager.instance.interactionText.text = "collect the medkit first!";
        }
        else if(lockedbyCollectible > GameManager.instance.collectibleCount)
        {
            GameManager.instance.interactionText.text = "Insufficient coins";
        }
        else
        {
            base.Interact(thePlayer);
            ///calls change scene function
            ChangeScene();
        }
    }
    // Update is called once per frame
    public void ChangeScene()
    {
        GameManager.instance.transition.SetTrigger("Start");
        ///load the scene by their index in the build
        GameManager.instance.GoToScene(targetSceneIndex);
    }
}
