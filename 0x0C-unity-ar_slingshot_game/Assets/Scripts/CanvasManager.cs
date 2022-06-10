using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    /// <summary>
    /// Sphere GameObject
    /// </summary>
    public GameObject ammo;

    /// <summary>
    /// Array of gameobjects that gets the ingame panels
    /// </summary>
    public GameObject[] inGamePanels;

    public GameObject startButton;
    /// <summary>
    /// OnStartButton event that executes the game
    /// </summary>
    public void OnStartButton()
    {
        audiosource.Play();
        ammo.SetActive(true);
        inGamePanels[0].SetActive(true);
        inGamePanels[1].SetActive(true);
        startButton.SetActive(false);
        
    }

    /// <summary>
    /// OnRestart event that restarts the entire scene
    /// </summary>
    public void OnRestart()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// OnExit event close the program
    /// </summary>
    public void OnExit()
    {
        Application.Quit();
    }



}
