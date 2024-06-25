/*
 * Author: Javier Chen Yuhong
 * Date: 25/06/2024
 * Description: 
 * Contains functions related to the Spyglass.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Spyglass class, inheriting from Collectible, manages the behavior of the Spyglass collectible item.
/// When interacted with, it activates a linked platform.
/// </summary>
public class Spyglass : Collectible
{
    /// <summary>
    /// The platform that is linked to the Spyglass. This platform will appear when the Spyglass is collected.
    /// </summary>
    public GameObject linkedPlatform;

    /// <summary>
    /// Overrides the Interact method from the Collectible base class.
    /// Activates the linked platform, calls the base Interact method, and triggers the collection process.
    /// </summary>
    /// <param name="thePlayer">The player who interacts with the Spyglass.</param>
    public override void Interact(Player thePlayer)
    {
        // Activate the linked platform
        linkedPlatform.SetActive(true);

        // Call the base class Interact method
        base.Interact(thePlayer);

        // Play collection audio and destroy the collectible
        Collected();
    }
}

