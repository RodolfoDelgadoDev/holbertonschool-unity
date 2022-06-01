using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CanvasManager class that defines the logic of the UI of the game
/// </summary>
public class CanvasManager : MonoBehaviour
{
    /// <summary>
    /// AudioSource of the canvas
    /// </summary>
    public AudioSource audiosource;

    /// <summary>
    /// Array of audioClips to play Audios
    /// </summary>
    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnStartButton event that executes the game
    /// </summary>
    public void OnStartButton()
    {
        audiosource.Play();
    }
}
