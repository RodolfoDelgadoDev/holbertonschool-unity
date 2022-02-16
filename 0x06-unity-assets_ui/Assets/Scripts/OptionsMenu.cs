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
    public void Back()
    {
        prevScene = PlayerPrefs.GetInt("PrevScene");
        SceneManager.LoadSceneAsync(prevScene);
    }
}
