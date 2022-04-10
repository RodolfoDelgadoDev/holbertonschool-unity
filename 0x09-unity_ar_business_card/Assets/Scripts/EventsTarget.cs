using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

/// <summary>
/// Class EventsTarget
/// </summary>
public class EventsTarget : MonoBehaviour
{
    /// <summary>
    /// public GameObject arrays that takes the images
    /// </summary>
    public GameObject[] images;
    

    /// <summary>
    /// OnTargLost Event
    /// </summary>
    public void OnTargLost()
    {
        foreach (GameObject im in images)
        {
            im.SetActive(false);
        }
    }

    /// <summary>
    /// OnTarg Event
    /// </summary>
    public void OnTarg()
    {
        foreach (GameObject im in images)
        {
            im.SetActive(true);
            Animator an = im.GetComponent<Animator>();
            an.Play("Tracked");
        }
    }
}
