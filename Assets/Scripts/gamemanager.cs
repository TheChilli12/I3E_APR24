/*
 * Author: Javier Chen Yuhong
 * Date: 13/06/2024
 * Description: 
 * Handles systems of the game such as HP, score and collectible count
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    public TextMeshProUGUI interactionText;

    /// <summary>
    /// Status of the Special Collectible
    /// </summary>
    [SerializeField]
    public bool specialCollected = false;

    /// <summary>
    /// Status of the first objective
    /// </summary>
    [SerializeField]
    public bool objective1 = false;

    /// <summary>
    /// The UI text that stores the player score
    /// </summary>
    public TextMeshProUGUI healthText;

    /// <summary>
    /// The UI text that stores the player's objective
    /// </summary>
    public TextMeshProUGUI currentObjective;

    /// <summary>
    /// The current health of the player
    /// </summary>
    public int currentHealth = 3;

    /// <summary>
    /// The count of collectibles collected.
    /// </summary>
    public int collectibleCount = 0;

    /// <summary>
    /// The current score of the player
    /// </summary>
    int currentScore = 0;

    /// <summary>
    /// Increases the score of the player by <paramref name="scoreToAdd"/>
    /// </summary>
    /// <param name="scoreToAdd">The amount to increase by</param>

    public void objective1complete()
    {
        currentObjective.text = "- Exit the ship and collect the coins";
    }

    public void IncreaseScore(int scoreToAdd)
    {
        // Increase the score of the player by scoreToAdd
        currentScore += scoreToAdd;

        // Increase the collectibleCount of the player by 1
        collectibleCount += 1;
        // scoreText.text = currentScore.ToString();
    }

    public void ChangeHealth(int hpToChange)
    {
        // Change the health of the player by hpToChange
        currentHealth += hpToChange;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        healthText.text = "Health remaining: "+ currentHealth.ToString();
    }

    public void InstaKill()
    {
        // Change the health of the player to 0, simulates instakill
        currentHealth = 0;
        healthText.text = "Health remaining: "+ currentHealth.ToString();
    }


    /// <summary>
    /// The UI text that stores the player score
    /// </summary>
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void RaycastOn()
    {
        interactionText.gameObject.SetActive(true);
    }

    public void RaycastOff()
    {
        interactionText.gameObject.SetActive(false);
    }
}
