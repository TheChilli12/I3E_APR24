/*
 * Author: Javier Chen Yuhong
 * Date: 24/06/2024
 * Description: 
 * Contains functions related to the damage over time mechanic.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard_dot : MonoBehaviour
{
    /// <summary>
    /// The time it takes for damage to be applied to the player
    /// </summary>
    float time = 1f;

    /// <summary>
    /// The damage to be applied to the player
    /// </summary>
    public int dmg = 1;

    /// <summary>
    /// The boolean to check if the player is supposed to take damage
    /// </summary>
    bool takeDamage = true;

    [SerializeField]
    private AudioSource damageAudio;

    // function for if the player stays contact with the hazard
    private void OnTriggerStay(Collider other)
    {
        // checks if player collides with hazard
        if(other.gameObject.tag == "Player")
        {
            // Starts the damage taking
            StartCoroutine(TakeDamage(time));
        }
    }
    IEnumerator TakeDamage(float time)
    {
        if(takeDamage)
        {
            damageAudio.Play();
            GameManager.instance.ChangeHealth(dmg);
            takeDamage = !takeDamage;
            yield return new WaitForSeconds(time);
            takeDamage = !takeDamage;
        }
    }
}
