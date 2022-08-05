using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

/// <summary>
/// PauseMenu class to manage the Pasue menu
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public GameObject cam;
    public GameObject player;
    private int actualScene;

    private MyInputs inputActions;

    private void Awake()
    {
        inputActions = new MyInputs();
        inputActions.Enable();
        inputActions.Player.Menu.performed += value => (GameIsPause ? (Action)Resume : Pause)(); 

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        player.GetComponent<PlayerController>().enabled = true;
        cam.GetComponent<CameraController>().enabled = true;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        player.GetComponent<PlayerController>().enabled = false;
        cam.GetComponent<CameraController>().enabled = false;

    }
    public void Restart()
    {
        Time.timeScale = 1f;
        actualScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualScene);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        actualScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("PrevScene", actualScene);
        GameIsPause = false;
        player.GetComponent<PlayerController>().enabled = true;
        cam.GetComponent<CameraController>().enabled = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);

    }
}
