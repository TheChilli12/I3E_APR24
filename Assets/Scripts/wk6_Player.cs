/*
 * Author: Elyas Chua-Aziz
 * Date: 06/05/2024
 * Description: 
 * Contains functions related to the Player such as increasing score.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The UI text that stores the player score
    /// </summary>
    public TextMeshProUGUI healthText;

    /// <summary>
    /// The current health of the player
    /// </summary>
    int currentHealth = 5;

    /// <summary>
    /// The UI text that stores the player score
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// The current score of the player
    /// </summary>
    int currentScore = 0;

    /// <summary>
    /// The current Interactable of the player
    /// </summary>
    Interactable currentInteractable;


    /// <summary>
    /// Increases the score of the player by <paramref name="scoreToAdd"/>
    /// </summary>
    /// <param name="scoreToAdd">The amount to increase by</param>
    public void IncreaseScore(int scoreToAdd)
    {
        // Increase the score of the player by scoreToAdd
        currentScore += scoreToAdd;

        scoreText.text = currentScore.ToString();
    }

        public void ChangeHealth(int hpToChange)
    {
        // Change the health of the player by hpToChange
        currentHealth += hpToChange;

        healthText.text = "Health remaining: "+ currentHealth.ToString();
    }

    /// <summary>
    /// Update the player's current Interactable
    /// </summary>
    /// <param name="newInteractable">The interactable to be updated</param>
    public void UpdateInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
    }

    /// <summary>
    /// Callback function for the Interact input action
    /// </summary>
    void OnInteract()
    {
        // Check if the current Interactable is null
        if(currentInteractable != null)
        {
            // Interact with the object
            currentInteractable.Interact(this);
        }
    }
}
