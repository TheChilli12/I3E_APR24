/*
 * Author: Javier Chen Yuhong
 * Date: 30/06/2024
 * Description: 
 * Contains functions related to instakill and damage hazards.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    /// <summary>
    /// The amount of damage inflicted on the player upon contact with the hazard.
    /// </summary>
    public int damageAmount = -1;

    /// <summary>
    /// The audio clip played when the player collides with the hazard.
    /// </summary>
    [SerializeField]
    private AudioClip damageAudio;

    /// <summary>
    /// Triggers when another collider enters this hazard's trigger collider.
    /// </summary>
    /// <param name="other">The collider that entered this hazard's trigger collider.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Player" tag.
        if (other.gameObject.CompareTag("Player"))
        {
            // Play the damage audio at the hazard's position.
            AudioSource.PlayClipAtPoint(damageAudio, transform.position, 1f);

            // Damage the player by calling the GameManager's ChangeHealth function.
            GameManager.instance.ChangeHealth(damageAmount);
        }
    }
}
