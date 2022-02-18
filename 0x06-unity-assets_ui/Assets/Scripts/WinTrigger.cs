using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// WinTrigger class that stops the timer and change de color of the text and the fontsize
/// </summary>
public class WinTrigger : MonoBehaviour
{
    public Text countdown;
    public GameObject player;
    public GameObject winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winCanvas.SetActive(true);
        }
    }
}
