/*
 * Author: Javier Chen Yuhong
 * Date: 06/06/2024
 * Description: 
 * The Collectible will destroy itself after being collided with.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    /// <summary>
    /// The AudioClip played upon collection.
    /// </summary>
    [SerializeField]
    private AudioClip collectAudio;

    /// <summary>
    /// The score value that this collectible is worth.
    /// </summary>
    public int myScore = 5;

    /// <summary>
    /// Performs actions related to collection of the collectible
    /// </summary>
    public void Collected()
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        // Destroy the attached GameObject
        Destroy(gameObject);
    }
    
    /// <summary>
    /// Handles the collectibles interaction.
    /// Increase the player's score and destroy itself
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        thePlayer.IncreaseScore(myScore);
        Collected();
    }
}
