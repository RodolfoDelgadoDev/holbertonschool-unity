using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// MainMenu class that let the player move between scenes.
/// </summary>
public class MainMenu : MonoBehaviour
{
    private int actualScene;
    public AudioSource buttonRellover;
    public AudioSource buttonClick;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Inverted"))
        {
            PlayerPrefs.SetInt("Inverted", -1);
        }
    }
    public void LevelSelect(int level)
    {
        if (level == 1)
        {
            SceneManager.LoadScene(2);
        }
        if (level == 2)
        {
            SceneManager.LoadScene(3);
        }
        if (level == 3)
        {
            SceneManager.LoadScene(4);
        }
    }
    public void Options()
    {
        actualScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("PrevScene", actualScene);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }

    public void HoverSound()
    {
        buttonRellover.PlayOneShot(buttonRellover.clip);
    }

    public void ClickSound()
    {
        buttonClick.PlayOneShot(buttonClick.clip);
    }
    
}
