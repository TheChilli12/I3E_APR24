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

    public bool objective1Current = true;

    public bool objective2Current = false;

    public bool objective3Current = false;

    public bool objective4Current = false;

    public bool objective5Current = false;

    /// <summary>
    /// Increases the score of the player by <paramref name="scoreToAdd"/>
    /// </summary>
    /// <param name="scoreToAdd">The amount to increase by</param>

    public void objective1complete()
    {
        objective2Current = true;
        currentObjective.text = $"- Exit the ship and collect the coins {collectibleCount}/5";
    }

    public void IncreaseScore(int scoreToAdd)
    {
        // Increase the score of the player by scoreToAdd
        currentScore += scoreToAdd;

        // Increase the collectibleCount of the player by 1
        collectibleCount += 1;
        scoreText.text = currentScore.ToString();

        if (collectibleCount == 5)
        {
            objective2Current = false;
            objective3Current = true;
        }
        else if (collectibleCount == 10)
        {
            objective3Current = false;
            objective4Current = true;
        }
        else if (collectibleCount == 10 && specialCollected == true)
        {
            objective4Current = false;
            objective5Current = true;
        }

        UpdateObjectiveText();
    }

    private void UpdateObjectiveText()
    {
        if (objective2Current)
        {
            currentObjective.text = $"- Exit the ship and collect the coins {collectibleCount}/5 \n- Hint: The collect the magnifying glass to see what is supposed to be seen";
        }
        else if (objective3Current)
        {
            currentObjective.text = $"- Find the remaining coins hidden in the ruins {collectibleCount - 5}/5";
        }
        else if (objective4Current)
        {
            currentObjective.text = $"- Obtain the blue crystal";
        }
        else if (objective5Current)
        {
            currentObjective.text = $"- Return to the ship and place the crystal in the power source";
        }
    }

    public void ChangeHealth(int hpToChange)
    {
        // Change the health of the player by hpToChange
        currentHealth += hpToChange;
        currentHealth = Mathf.Max(0, currentHealth);
        healthText.text = $"Health remaining: {currentHealth}";
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

    /// <summary>
    /// Activates the interaction text UI element.
    /// </summary>
    public void RaycastOn()
    {
        interactionText.gameObject.SetActive(true);
    }

    /// <summary>
    /// Deactivates the interaction text UI element.
    /// </summary>
    public void RaycastOff()
    {
        interactionText.gameObject.SetActive(false);
    }
}
