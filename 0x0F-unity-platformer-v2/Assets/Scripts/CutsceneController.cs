using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;
    public GameObject timercan;
    public GameObject cutcam;

    public void EndAnimationEvent()
    {
        cam.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
        timercan.SetActive(true);
        cutcam.SetActive(false);
    }
}