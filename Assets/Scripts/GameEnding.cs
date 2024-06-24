/*
 * Author: Javier Chen Yuhong
 * Date: 24/06/2024
 * Description: 
 * Contains functions related to the Ending of the game.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : SceneChanger
{
    public override void Interact(Player thePlayer)
    {
        ///Checks if collision is with player
        if (GameManager.instance.specialCollected == true)
        {
            ///calls change scene function
            ChangeScene();
        }
        else
        {
            ///Shows player they have not collected the specialCollected item
            GameManager.instance.interactionText.text = "Power source Missing!";
        }
    }
}
