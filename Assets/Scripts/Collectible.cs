/*
 * Author: Javier Chen Yuhong
 * Date: 17/05/2024
 * Description: 
 * The Collectible will destroy itself after being interacted with and will provide a score to the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible1 : MonoBehaviour
{
    /// <summary>
    /// The score value that this collectible is worth.
    /// </summary>
    public int myScore = 5;



    /// <summary>
    /// Performs actions related to collection of the collectible
    /// </summary>
    public void Collected()
    {
        // Destroy the attached GameObject
        Destroy(gameObject);
    }
}
