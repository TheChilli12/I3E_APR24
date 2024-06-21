/*
 * Author: Javier Chen Yuhong
 * Date: 13/06/2024
 * Description: 
 * Contains functions related to the Player such as raycasting
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The current Interactable of the player
    /// </summary>
    Interactable currentInteractable;

    [SerializeField]
    Transform playerCamera;

    [SerializeField]
    float interactionDistance;

    private void Update()
    {
        ///Raycast Ray is created
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);
        RaycastHit hitInfo;
        if(Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            Debug.Log(hitInfo.transform.name);
            ///Checks if raycast hits an interactable class object
            if(hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                ///Shows interactionText raycast hits an interactable class object
                GameManager.instance.RaycastOn();
            }
            else
            {
                currentInteractable = null;
                GameManager.instance.RaycastOff();
            }
        }
        else
        {
            ///Sets currentInteractable to null
            currentInteractable = null;
            ///Hides interactionText
            GameManager.instance.RaycastOff();
        }
    }

    /// <summary>
    /// Update the player's current Interactable
    /// </summary>
    /// <param name="newInteractable">The interactable to be updated</param>

    // public void UpdateInteractable(Interactable newInteractable)
    // {
    //     currentInteractable = newInteractable;
    // }

    /// <summary>
    /// Callback function for the Interact input action
    /// </summary>
    void OnInteract()
    {
        // Check if the current Interactable is null
        if(currentInteractable != null)
        {
            // Interact with the object
            currentInteractable.Interact(this);
        }
    }
}
