/*
 * Author: Javier Chen Yuhong
 * Date: 30/06/2024
 * Description: 
 * The door that opens when the player is near it and presses the interact button.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The door that opens when the player is near it and presses the interact button.
/// </summary>
public class Door : Interactable
{
    /// <summary>
    /// The pivot point for the door.
    /// </summary>
    public GameObject doorPivot;

    /// <summary>
    /// The number of collectibles required to open the door.
    /// </summary>
    public int openReq;

    /// <summary>
    /// The audio clip to play when the door unlocks.
    /// </summary>
    [SerializeField]
    private AudioClip unlockAudio;

    /// <summary>
    /// Flags if the door is open.
    /// </summary>
    private bool opened = false;

    /// <summary>
    /// Flags if the door is locked.
    /// </summary>
    private bool locked = false;

    /// <summary>
    /// Duration for the door to open.
    /// </summary>
    public float openDuration = 1f;

    /// <summary>
    /// Distance the door should move downwards.
    /// </summary>
    public float openDistance = 3f;

    /// <summary>
    /// Handles the door's interaction.
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the door.</param>
    public override void Interact(Player thePlayer)
    {
        // Check if the player has collected enough items to open the door.
        if (GameManager.instance.collectibleCount >= openReq)
        {
            // Call the Interact function from the base Interactable class.
            base.Interact(thePlayer);

            // Play the unlock audio clip.
            AudioSource.PlayClipAtPoint(unlockAudio, transform.position, 3f);

            // Start the coroutine to open the door.
            StartCoroutine(OpenDoor());
        }
        else
        {
            GameManager.instance.interactionText.text = "Insufficient coins";
        }
    }

    /// <summary>
    /// Handles the door opening.
    /// </summary>
    private IEnumerator OpenDoor()
    {
        // Door should open only when it is not locked and not already opened.
        if (!locked && !opened)
        {
            // Store the initial and target positions.
            Vector3 initialPosition = doorPivot.transform.position;
            Vector3 targetPosition = initialPosition + new Vector3(0, -openDistance, 0);

            float elapsedTime = 0f;

            // Smoothly move the door downwards.
            while (elapsedTime < openDuration)
            {
                // Interpolate the door's position between the initial and target positions.
                doorPivot.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / openDuration);

                // Increment the elapsed time.
                elapsedTime += Time.deltaTime;

                // Yield control back to the Unity engine until the next frame.
                yield return null;
            }

            // Ensure the door reaches the target position.
            doorPivot.transform.position = targetPosition;

            // Mark the door as opened.
            opened = true;
        }
    }
}
