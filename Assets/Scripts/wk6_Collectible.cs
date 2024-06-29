/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
 * Description: 
 * The Collectible will destroy itself after being collided with.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Collectible will destroy itself after being collided with.
/// </summary>
public class Collectible : Interactable
{
    /// <summary>
    /// The AudioClip played upon collection.
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// Performs actions related to the collection of the collectible.
    /// </summary>
    public void Collected()
    {
        // Plays the audio clip at the collectible's position with volume 1.
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        
        // Destroy the attached GameObject.
        Destroy(gameObject);
    }
    
    /// <summary>
    /// Handles the collectible's interaction.
    /// Increases the player's score and destroys itself.
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public override void Interact(Player thePlayer)
    {
        // Calls the Interact function from the base Interactable class.
        base.Interact(thePlayer);

        // Calls the function that plays the audio and destroys the collectible.
        Collected();
    }
}
