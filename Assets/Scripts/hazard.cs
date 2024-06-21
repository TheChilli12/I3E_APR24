/*
 * Author: Javier Chen Yuhong
 * Date: 13/06/2024
 * Description: 
 * Contains functions related to instakill and damage hazards
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    /// <summary>
    /// How much damage is done to the player
    /// </summary>
    public int damageAmount = -1;
    /// <summary>
    /// boolean to check whether it will instantly kill the player
    /// </summary>
    public bool instaKill = false;
    /// <summary>
    /// Audio played upon contact with hazard
    /// </summary>
    [SerializeField]
    private AudioClip damageAudio;
    private void OnTriggerEnter(Collider other)
    {
        /// Check if collided with player
        if(other.gameObject.tag == "Player")
        {
            /// Check if hazard is instakill
            if(instaKill == false)
            {
                ///Plays damage audio
                AudioSource.PlayClipAtPoint(damageAudio, transform.position, 1f);
                ///calls ChangeHealth function to damage the player and update health
                GameManager.instance.ChangeHealth(damageAmount);
            }
            /// Check if hazard is instakill
            else
            {
                ///Plays damage audio
                AudioSource.PlayClipAtPoint(damageAudio, transform.position, 1f);
                ///Xalls Instakill function to damage the player and update health to 0
                GameManager.instance.InstaKill();
            }
        }
    }
}
