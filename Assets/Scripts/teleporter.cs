/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
 * Description: 
 * Teleporter that will be used to change scenes
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : Interactable
{
    /// <summary>
    /// Indicates if the teleporter is locked by a medkit collectible.
    /// </summary>
    [SerializeField]
    public bool lockedbyMedkit;

    /// <summary>
    /// The number of collectibles required to unlock the teleporter.
    /// </summary>
    public int lockedbyCollectible = 0;

    /// <summary>
    /// The scene index the teleporter transports the player to.
    /// </summary>
    public int targetSceneIndex;

    /// <summary>
    /// Audio clip played when the teleporter is unlocked.
    /// </summary>
    [SerializeField]
    private AudioClip unlockAudio;

    /// <summary>
    /// Audio clip played when the player exits through the teleporter.
    /// </summary>
    [SerializeField]
    private AudioClip exitAudio;

    /// <summary>
    /// Material used when the teleporter is locked.
    /// </summary>
    [SerializeField]
    public Material lockedMaterial;

    /// <summary>
    /// Material used when the teleporter is unlocked.
    /// </summary>
    [SerializeField]
    public Material unlockedMaterial;

    /// <summary>
    /// The GameObject representing the door of the teleporter.
    /// </summary>
    public GameObject door;
    
    /// <summary>
    /// The renderer component of the teleporter door.
    /// </summary>
    private Renderer doorRenderer;

    private void Start()
    {
        // Get the renderer component of the door if it exists
        if (door != null)
        {
            doorRenderer = door.GetComponent<Renderer>();
        }
    }

    private void Update()
    {
        // Update the door material based on lock status
        if (doorRenderer != null)
        {
            if (lockedbyMedkit || lockedbyCollectible > GameManager.instance.collectibleCount)
            {
                doorRenderer.material = lockedMaterial;
            }
            else
            {
                //replaces lock material with unlock material indicating the door is open
                doorRenderer.material = unlockedMaterial;
                //Plays the unlock audio
                AudioSource.PlayClipAtPoint(unlockAudio, transform.position, 3f);
                // Stop updating once unlocked
                enabled = false;  
            }
        }
    }

    /// <summary>
    /// Handles the interaction with the teleporter.
    /// Displays a message if the teleporter is locked, otherwise changes the scene.
    /// </summary>
    /// <param name="thePlayer">The player interacting with the teleporter.</param>
    public override void Interact(Player thePlayer)
    {
        // Check if the teleporter is locked by a medkit or insufficient collectibles
        if (lockedbyMedkit == true)
        {
            GameManager.instance.interactionText.text = "Collect the medkit first!";
        }
        else if (lockedbyCollectible > GameManager.instance.collectibleCount)
        {
            GameManager.instance.interactionText.text = "Insufficient coins";
        }
        else
        {
            base.Interact(thePlayer);
            // Call the function to change scene
            ChangeScene();
        }
    }

    /// <summary>
    /// Changes the scene to the target scene index.
    /// Plays the exit audio clip when changing scenes.
    /// </summary>
    public void ChangeScene()
    {
        AudioSource.PlayClipAtPoint(exitAudio, transform.position, 1f);
        // Load the scene by its index in the build settings
        GameManager.instance.GoToScene(targetSceneIndex);
    }
}
