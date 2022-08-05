using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Time trigger class that detects when the player starts moving
/// </summary>
public class TimerTrigger : MonoBehaviour
{

    public GameObject player; 
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Timer>().enabled = true;
            Destroy(gameObject);
        }
    }
}
