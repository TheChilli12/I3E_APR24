/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
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
    /// The current Interactable object the player can interact with.
    /// </summary>
    Interactable currentInteractable;

    /// <summary>
    /// The player's camera used for raycasting.
    /// </summary>
    [SerializeField]
    Transform playerCamera;

    /// <summary>
    /// The maximum distance for interaction raycasting.
    /// </summary>
    [SerializeField]
    float interactionDistance;

    private void Update()
    {
        // Draws a debug line representing the raycast direction and distance.
        Debug.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactionDistance), Color.red);

        // Stores information about the raycast hit.
        RaycastHit hitInfo;

        // Performs a raycast from the player's camera forward to check for interactable objects.
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hitInfo, interactionDistance))
        {
            // Logs the name of the object hit by the raycast.
            Debug.Log(hitInfo.transform.name);

            // Checks if the raycast hit an object with an Interactable component.
            if (hitInfo.transform.TryGetComponent<Interactable>(out currentInteractable))
            {
                // Shows the interaction text when the raycast hits an interactable object.
                GameManager.instance.RaycastOn();
            }
            else
            {
                // Displays the interaction prompt text.
                GameManager.instance.interactionText.text = "\"e\" to interact";

                // Sets the current interactable to null if the hit object is not interactable.
                currentInteractable = null;

                // Hides the interaction text.
                GameManager.instance.RaycastOff();
            }
        }
        else
        {
            // Sets the current interactable to null if no object is hit by the raycast.
            currentInteractable = null;

            // Hides the interaction text.
            GameManager.instance.RaycastOff();
        }
    }

    /// <summary>
    /// Callback function for the Interact input action.
    /// Interacts with the current interactable object if there is one.
    /// </summary>
    void OnInteract()
    {
        // Check if the current Interactable is null
        if (currentInteractable != null)
        {
            // Calls the Interact method on the current interactable object.
            currentInteractable.Interact(this);
        }
    }
}
