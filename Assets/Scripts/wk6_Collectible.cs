/*
 * Author: Javier Chen Yuhong
 * Date: 18/06/2024
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
        //Plays audio upon collection
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
        ///Increases player score by collectible point value
        GameManager.instance.currentObjective.text = "- Exit the ship and collect the coins " + GameManager.instance.collectibleCount + "/5".ToString();
        GameManager.instance.IncreaseScore(myScore);
        ///calls function that plays audio and destroys collectible
        Collected();
    }
}
