/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
 * Description: 
 * Contains functions related to the healthpack collectible which can restore player health and complete an objective.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a healthpack collectible in the game that can restore player health and potentially complete an objective.
/// </summary>
public class Healthpack : Collectible
{
    /// <summary>
    /// The teleporter associated with completing the first objective. 
    /// It will be unlocked when this healthpack is collected if it is an objective medkit.
    /// </summary>
    public SceneChanger objective1teleporter;

    /// <summary>
    /// Indicates whether this healthpack is the special medkit needed to complete the first objective.
    /// </summary>
    public bool objectiveMedkit = false;

    /// <summary>
    /// The amount of health that this healthpack restores to the player.
    /// </summary>
    public int myHealth = 1;

    /// <summary>
    /// Handles the interaction between the player and this healthpack.
    /// If this healthpack is the objective medkit, it completes the first objective,
    /// unlocks the associated teleporter, restores health to the player, and triggers collectible behavior.
    /// </summary>
    /// <param name="thePlayer">The player who interacts with the healthpack.</param>
    public override void Interact(Player thePlayer)
    {
        // If this healthpack is the objective medkit, complete the first objective and unlock the teleporter.
        if (objectiveMedkit == true)
        {
            GameManager.instance.medkitCollected = true;
            GameManager.instance.UpdateObjectiveText();
            objective1teleporter.lockedbyMedkit = false;
        }

        // Call the base interaction behavior.
        base.Interact(thePlayer);

        // Increase the player's health by the healthpack's value.
        GameManager.instance.ChangeHealth(myHealth);

        // Play the collection sound and destroy the healthpack.
        Collected();
    }
    
    /// <summary>
    /// Destroys the healthpack if the special collectible has already been collected.
    /// </summary>
    void Awake()
    {
        if (GameManager.instance.specialCollected == true)
        {
            Destroy(gameObject);
        }
    }
}
