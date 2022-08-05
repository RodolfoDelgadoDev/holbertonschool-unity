using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// OptionsMenu class for the Options scene
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    private int prevScene;
    public Toggle checkBox;
    public GameObject[] elements;
    public GameObject[] keybindingOptions;
    private bool check = true;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Inverted") == -1)
        {
            checkBox.isOn = true;
        }
        else
        {
            checkBox.isOn = false;
        }
    }
    public void Back()
    {
        prevScene = PlayerPrefs.GetInt("PrevScene");
        SceneManager.LoadSceneAsync(prevScene);
    }

    public void Apply()
    {
        if (checkBox.isOn)
        {
            PlayerPrefs.SetInt("Inverted", -1);
        }
        else
        {
            PlayerPrefs.SetInt("Inverted", 1);
        }
        prevScene = PlayerPrefs.GetInt("PrevScene");
        SceneManager.LoadScene(prevScene);
        
    }

    public void KeyBinding()
    {
        if (check == true)
            check = false;
        else
            check = true;
        foreach (var elem in elements)
        {
            elem.SetActive(check);
        }
        foreach (var keys in keybindingOptions)
        {
            keys.SetActive(!check);
        }
    }
}
