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
    public GameObject togglegameobject;

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GameController")
        {
            if (togglegameobject.GetComponent<Toggle>().isOn)
            {
                Bgmusic.Play();
                togglegameobject.GetComponent<Toggle>().isOn = false;
            }
            else
            {
                Bgmusic.Pause();
                togglegameobject.GetComponent<Toggle>().isOn = true;
            }
        }
    }
}
