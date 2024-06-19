
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
    /// The hp value that this collectible restores.
    /// </summary>
    public int myHealth = 1;

    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        ///Increases player HP by collectible point value
        GameManager.instance.ChangeHealth(myHealth);
        ///calls function that plays audio and destroys collectible
        Collected();
    }
}
