/*
 * Author: Javier Chen Yuhong
 * Date: 30/06/2024
 * Description: 
 * Specialized type of Collectible that increases player score upon interaction.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specialized type of Collectible that increases player score upon interaction.
/// </summary>
public class CoinCollectible : Collectible
{
    /// <summary>
    /// Handles the collectible's interaction.
    /// Increases the player's score and destroys itself.
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public override void Interact(Player thePlayer)
    {
        // Calls the Interact function from the base Collectible class.
        base.Interact(thePlayer);

        // Increases the player's score by the collectible point value.
        GameManager.instance.IncreaseScore();

        // Calls the function that plays the audio and destroys the collectible.
        Collected();
    }
}
