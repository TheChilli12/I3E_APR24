/*
 * Author: Javier Chen Yuhong
 * Date: 13/06/2024
 * Description: 
 * Contains functions related to the Player such as increasing score.
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

    [SerializeField]
    TextMeshProUGUI interactionText;

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
                interactionText.gameObject.SetActive(true);    
            }
            else
            {
                currentInteractable = null;
                interactionText.gameObject.SetActive(false); 
            }
        }
        else
        {
            ///Sets currentInteractable to null
            currentInteractable = null;
            ///Hides interactionText
            interactionText.gameObject.SetActive(false); 
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
