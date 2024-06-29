/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
 * Description: 
 * Contains functions related to the damage over time mechanic.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard_dot : MonoBehaviour
{
    /// <summary>
    /// The time interval in seconds between each damage application.
    /// </summary>
    float time = 1f;

    /// <summary>
    /// The amount of damage to be applied to the player.
    /// </summary>
    public int dmg = 1;

    /// <summary>
    /// A boolean flag to check if the player should take damage.
    /// </summary>
    bool takeDamage = true;

    /// <summary>
    /// The audio source that plays when the player takes damage.
    /// </summary>
    [SerializeField]
    private AudioSource damageAudio;

    /// <summary>
    /// Called when another collider stays in contact with this collider.
    /// If the other collider is tagged as "Player", it starts the damage over time coroutine.
    /// </summary>
    /// <param name="other">The other collider that stays in contact.</param>
    private void OnTriggerStay(Collider other)
    {
        // Checks if player collides with hazard
        if (other.gameObject.tag == "Player")
        {
            // Starts the damage taking
            StartCoroutine(TakeDamage(time));
        }
    }

    /// <summary>
    /// Coroutine to apply damage to the player at regular intervals.
    /// Plays the damage audio and reduces the player's health.
    /// </summary>
    
    /// <param name="time">The time interval between each damage application.</param>
    /// <returns>IEnumerator for coroutine.</returns>
    IEnumerator TakeDamage(float time)
    {
        if (takeDamage)
        {
            // Play the damage audio clip
            damageAudio.Play();

            // Apply damage to the player's health
            GameManager.instance.ChangeHealth(-dmg);

            // Toggle the takeDamage flag to prevent immediate re-damage
            takeDamage = !takeDamage;

            // Wait for the specified time interval
            yield return new WaitForSeconds(time);

            // Toggle the takeDamage flag to allow damage again
            takeDamage = !takeDamage;
        }
    }
}