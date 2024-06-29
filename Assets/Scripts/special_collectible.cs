/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
 * Description: 
 * The Collectible will destroy itself after being collided with and allows players to end the game.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialCollectible : Collectible
{
    /// <summary>
    /// The portal GameObject that activates upon collecting this special item.
    /// </summary>
    public GameObject portal;

    /// <summary>
    /// The AudioSource that plays when the portal is opened.
    /// </summary>
    public AudioSource portalOpen;

    /// <summary>
    /// Handles the collectible's interaction.
    /// Increase the player's score and destroy itself.
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public override void Interact(Player thePlayer)
    {
        // Calls the base class Interact method.
        base.Interact(thePlayer);

        // Sets the specialCollected flag to true in the GameManager.
        GameManager.instance.specialCollected = true;

        // Increases the player's score.
        GameManager.instance.IncreaseScore();

        // Updates the objective text in the GameManager.
        GameManager.instance.UpdateObjectiveText();

        // Plays the portal opening sound.
        portalOpen.Play();

        // Activates the portal GameObject.
        portal.SetActive(true);

        // Calls function that plays audio and destroys the collectible.
        Collected();
    }
}