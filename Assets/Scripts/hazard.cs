using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damageAmount;
    public bool instaKill = false;
    [SerializeField]
    private AudioClip damageAudio;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(instaKill == false)
            {
                AudioSource.PlayClipAtPoint(damageAudio, transform.position, 1f);
                other.gameObject.GetComponent<Player>().ChangeHealth(damageAmount);
            }
            else
            {
                AudioSource.PlayClipAtPoint(damageAudio, transform.position, 1f);
                other.gameObject.GetComponent<Player>().Instakill();
            }
        }
    }
}
