/*
 * Author: Javier Chen Yuhong
 * Date: 18/06/2024
 * Description: 
 * The Collectible will destroy itself after being collided with.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : Collectible
{
    /// <summary>
    /// Handles the collectibles interaction.
    /// Increase the player's score and destroy itself
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        ///Increases player score by collectible point value
        GameManager.instance.IncreaseScore(myScore);
        GameManager.instance.currentObjective.text = "- Exit the ship and collect the coins " + GameManager.instance.collectibleCount + "/5".ToString();
        ///calls function that plays audio and destroys collectible
        Collected();
    }
}