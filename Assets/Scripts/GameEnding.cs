/*
 * Author: Javier Chen Yuhong
 * Date: 24/06/2024
 * Description: 
 * Contains functions related to the Ending of the game.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : SceneChanger
{
    /// <summary>
    /// Audio clip played when the game ending is activated.
    /// </summary>
    [SerializeField]
    private AudioClip offAudio;

    /// <summary>
    /// Audio clip played when the game ending is successfully achieved.
    /// </summary>
    [SerializeField]
    private AudioClip onAudio;

    /// <summary>
    /// The crystal GameObject that represents the power source.
    /// </summary>
    public GameObject crystal;

    /// <summary>
    /// Overrides the Interact method from the base class (SceneChanger).
    /// Triggers the game ending sequence if the special collectible is collected,
    /// otherwise provides feedback to the player.
    /// </summary>
    /// <param name="thePlayer">The player interacting with the game ending object.</param>
    public override void Interact(Player thePlayer)
    {
        // Check if the special collectible is collected
        if (GameManager.instance.specialCollected == true)
        {
            // Play success audio
            AudioSource.PlayClipAtPoint(onAudio, transform.position, 1f);
            
            // Activate the crystal GameObject
            crystal.SetActive(true);
            
            // Go to the game ending scene
            GameManager.instance.GoToScene(5);
        }
        else
        {
            // Play failure audio
            AudioSource.PlayClipAtPoint(offAudio, transform.position, 1f);
            
            // Provide feedback to the player
            GameManager.instance.interactionText.text = "Power source Missing!";
        }
    }
}

