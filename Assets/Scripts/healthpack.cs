
/*
 * Author: Javier Chen Yuhong
 * Date: 18/06/2024
 * Description: 
 * Contains functions related to the healthpack
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpack : Collectible
{
    /// <summary>
    /// The linked teleporter that completes objective 1
    /// </summary>
    public SceneChanger objective1teleporter;
    /// <summary>
    /// Determines if this is the medkit is objective medkit
    /// </summary>
    public bool objectiveMedkit = false;
    /// <summary>
    /// The hp value that this collectible restores.
    /// </summary>
    public int myHealth = 1;

    public override void Interact(Player thePlayer)
    {
        if (objectiveMedkit == true)
        {
            GameManager.instance.objective1complete();
            objective1teleporter.lockedbyMedkit = false;
        }
        base.Interact(thePlayer);
        ///Increases player HP by collectible point value
        GameManager.instance.ChangeHealth(myHealth);
        ///calls function that plays audio and destroys collectible
        Collected();
    }
}
