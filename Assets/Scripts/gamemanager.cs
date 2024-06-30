/*
 * Author: Javier Chen Yuhong
 * Date: 29/06/2024
 * Description: 
 * Handles systems of the game such as HP, score, and collectible count
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{    
    /// <summary>
    /// Single instance of the GameManager.
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// The UI text that stores the interaction message.
    /// </summary>
    [SerializeField]
    public TextMeshProUGUI interactionText;

    /// <summary>
    /// Status of the Special Collectible.
    /// </summary>
    [SerializeField]
    public bool specialCollected = false;

    /// <summary>
    /// Status of the Tutorial Healthpack.
    /// </summary>
    [SerializeField]
    public bool medkitCollected = false;

    /// <summary>
    /// The UI text that stores the player's health.
    /// </summary>
    public TextMeshProUGUI healthText;

    /// <summary>
    /// The UI image for the player spyglass (TextMeshPro image).
    /// </summary>
    public Image collectibleImage;
    
    /// <summary>
    /// The UI text that stores the player's objective.
    /// </summary>
    public TextMeshProUGUI currentObjective;

    /// <summary>
    /// The animator for the scene transition.
    /// </summary>
    public Animator transition;

    /// <summary>
    /// The duration of the scene transition.
    /// </summary>
    public float transitionTime = 1f;

    /// <summary>
    /// The current health of the player.
    /// </summary>
    public int currentHealth = 3;

    /// <summary>
    /// The count of collectibles collected.
    /// </summary>
    public int collectibleCount = 0;

    /// <summary>
    /// The UI text that stores the player score.
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// Increases the score of the player.
    /// </summary>
    public void IncreaseScore()
    {
        collectibleCount += 1;
        // Updates the objective text in the GameManager.
        GameManager.instance.UpdateObjectiveText();
    }

    /// <summary>
    /// Updates the objective text based on the current game state.
    /// </summary>
    public void UpdateObjectiveText()
    {
        if (collectibleCount >= 10 && specialCollected == true)
        {
            currentObjective.text = $"- Return to the ship and place the crystal in the power source";            
        }
        else if (collectibleCount >= 10)
        {
            currentObjective.text = $"- Obtain the blue crystal";
        }
        else if (collectibleCount >= 5)
        {
            currentObjective.text = $"- Find the remaining coins hidden in the ruins {collectibleCount - 5}/5";
        }
        else if (medkitCollected == true)
        {
            currentObjective.text = $"- Exit the ship and collect the coins {collectibleCount}/5 \n- Hint: Collect the magnifying glass to see what is supposed to be seen";
        }
        else if (medkitCollected == false)
        {
            currentObjective.text = $"- Collect the medkit located near the bed \n- (Optional) View the hazards detected on this foreign planet";
        }
    }

    /// <summary>
    /// Updates the objective text every frame.
    /// </summary>
    void Update()
    {
        // Calls the UpdateObjectiveText method every frame.
        UpdateObjectiveText();
    }

    /// <summary>
    /// Changes the health of the player by a specified amount.
    /// </summary>
    /// <param name="hpToChange">The amount to change the health by.</param>
    public void ChangeHealth(int hpToChange)
    {
        currentHealth += hpToChange;
        currentHealth = Mathf.Max(0, currentHealth);
        healthText.text = $"Health remaining: {currentHealth}";
        if (currentHealth == 0)
        {
            GoToScene(4);
        }
    }

    /// <summary>
    /// Changes the scene to the specified scene index.
    /// </summary>
    /// <param name="scene">The index of the scene to change to.</param>
    public void GoToScene(int scene)
    {
        // Starts the LoadLevel coroutine.
        StartCoroutine(Loadlevel(scene));
    }

    /// <summary>
    /// Coroutine to handle the scene loading with transition.
    /// </summary>
    /// <param name="scene">The index of the scene to load.</param>
    /// <returns></returns>
    public IEnumerator Loadlevel(int scene)
    {
        // Triggers the scene transition animation.
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
        transition.SetTrigger("End");
    }

    /// <summary>
    /// Restarts the game, resetting all relevant variables.
    /// </summary>
    public void RestartGame()
    {
        specialCollected = false;
        medkitCollected = false;
        currentHealth = 3;
        collectibleCount = 0;
        collectibleImage.gameObject.SetActive(false);
        healthText.text = $"Health remaining: {currentHealth}";
        UpdateObjectiveText();
    }

    /// <summary>
    /// Restarts the game from level 0.
    /// </summary>
    public void RestartGamelvl0()
    {
        //checks if the player has played through the last level before restarting the stats
        if (specialCollected == false)
        {
            medkitCollected = false;
            currentHealth = 3;
            healthText.text = $"Health remaining: {currentHealth}";
            UpdateObjectiveText();
        }
        else
        {
            healthText.text = $"Health remaining: {currentHealth}";
            UpdateObjectiveText();
        }
    }

    /// <summary>
    /// Restarts the game from level 1.
    /// </summary>
    public void RestartGamelvl1()
    {
        medkitCollected = true;
        currentHealth = 4;
        collectibleCount = 0;
        collectibleImage.gameObject.SetActive(false);
        healthText.text = $"Health remaining: {currentHealth}";
        UpdateObjectiveText();
    }

    /// <summary>
    /// Restarts the game from level 2.
    /// </summary>
    public void RestartGamelvl2()
    {
        medkitCollected = true;
        currentHealth = 4;
        collectibleCount = 5;
        collectibleImage.gameObject.SetActive(true);
        healthText.text = $"Health remaining: {currentHealth}";
        UpdateObjectiveText();
    }

    /// <summary>
    /// Ensures that only 1 Game manager exists at a time when moving from scene to scene
    /// </summary>
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
