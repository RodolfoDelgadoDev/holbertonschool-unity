using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Script of the timer
/// </summary>
public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float time;
    public GameObject Wincanvas;
    public Text FinalTime;
    public GameObject player;
    public GameObject cam;

    // Update is called once per frame
    void Update()
    {
        if (!Wincanvas.activeSelf)
        {
            time += UnityEngine.Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time % 60F);
            int milliseconds = Mathf.FloorToInt((time * 100F) % 100F);
            TimerText.text = minutes.ToString("0") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");

        }
        else
        {
            Win();
        }
    }

    public void Win()
    {
        FinalTime.text = TimerText.text;
        Time.timeScale = 0f;
        TimerText.enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        cam.GetComponent<CameraController>().enabled = false;
        this.enabled = false;
    }
}
