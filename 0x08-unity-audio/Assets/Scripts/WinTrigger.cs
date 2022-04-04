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
    public GameObject GameSoundObject;
    public GameObject VictorySoundGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            winCanvas.SetActive(true);
            AudioSource GameSound = GameSoundObject.GetComponent<AudioSource>();
            AudioSource VictorySound = VictorySoundGameObject.GetComponent<AudioSource>();
            GameSound.Stop();
            VictorySound.PlayOneShot(VictorySound.clip);
        }
    }
}
