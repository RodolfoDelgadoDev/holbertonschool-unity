using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// ButtonsEvents
/// </summary>
public class ButtonsEvents : MonoBehaviour
{
    public AudioSource Bgmusic;

    private Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }
    /// <summary>
    /// OnPressReset Event
    /// </summary>
    public void OnChangeMusicStatus()
    {
        if (toggle.isOn)
            Bgmusic.Play();
        else
            Bgmusic.Pause();
    }
}
