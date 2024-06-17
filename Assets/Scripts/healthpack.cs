using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpack : Interactable
{
    public int myHealth = 5;
    [SerializeField]
    private AudioClip collectAudio;

    public override void Interact(Player thePlayer)
    {
        base.Interact(thePlayer);
        GameManager.instance.ChangeHealth(myHealth);
        Collected();
    }

    public void Collected()
    {
        AudioSource.PlayClipAtPoint(collectAudio, transform.position, 1f);
        // Destroy the attached GameObject
        Destroy(gameObject);
    }
}
