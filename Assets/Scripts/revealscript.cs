/*
 * Author: Javier Chen Yuhong
 * Date: 30/06/2024
 * Description: 
 * Contains functions related to the Spyglass.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// The Spyglass class manages the behavior of the Spyglass collectible item, inheriting from Collectible.
/// When interacted with, it activates a linked platform and triggers the collection process.
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
        // Activates the linked platform associated with the Spyglass.
        linkedPlatform.SetActive(true);

        // Ensures that the collectible image is set active in the UI.
        if (GameManager.instance.collectibleImage != null)
        {
            GameManager.instance.collectibleImage.gameObject.SetActive(true);
        }

        // Calls the base class Interact method to handle basic collectible interactions.
        base.Interact(thePlayer);

        // Plays collection audio and destroys the collectible GameObject.
        Collected();
    }
}
