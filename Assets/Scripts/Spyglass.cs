using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spyglass : Collectible
{
    public GameObject linkedPlatform;

    public override void Interact(Player thePlayer)
    {
        linkedPlatform.SetActive(true);
        base.Interact(thePlayer);
        ///calls function that plays audio and destroys collectible
        Collected();
    }
}
