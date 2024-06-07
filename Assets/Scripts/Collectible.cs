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

    /// <summary>
    /// Callback function for when a collision occurs
    /// </summary>
    /// <param name="collision">Collision event data</param>

    // private void OnCollisionEnter(Collision collision)
    // {
    //     // Check if the object that
    //     // touched me has a 'Player' tag
    //     if(collision.gameObject.tag == "Player")
    //     {
    //         collision.gameObject.GetComponent<Player>().UpdateCollectible(this);
    //         // Look for the "Player" component on the GameObject that collided with me.
    //         // Call the IncreaseScore function in the found "Player" component.
    //     }
    // }
    //     private void OnCollisionExit(Collision collision)
    // {
    //     if(collision.gameObject.tag == "Player")
    //     {
    //         collision.gameObject.GetComponent<Player>().UpdateCollectible(null);
    //         //Tells the scipt the collectible is out of range and cannot be collected
    //     }
    // }
}
