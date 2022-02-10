using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script of the timer
/// </summary>
public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float Time;

    // Update is called once per frame
    void Update()
    {
        Time += UnityEngine.Time.deltaTime;
        int minutes = Mathf.FloorToInt(Time / 60F);
        int seconds = Mathf.FloorToInt(Time % 60F);
        int milliseconds = Mathf.FloorToInt((Time * 100F) % 100F);
        TimerText.text = minutes.ToString("0") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }
}
