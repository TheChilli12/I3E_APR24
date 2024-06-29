/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
 * Description: 
 * Contains functions related to the Interactable
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for all interactable objects in the game.
/// </summary>
public class Interactable : MonoBehaviour
{
    /// <summary>
    /// Stores the current player that can interact with the object.
    /// </summary>
    protected Player currentPlayer;

    /// <summary>
    /// Execute the object's interaction.
    /// </summary>
    /// <param name="thePlayer">The player that interacted with the object.</param>
    public virtual void Interact(Player thePlayer)
    {
        // Logs a message indicating that the object was interacted with.
        Debug.Log(gameObject.name + " was interacted with.");
    }
}