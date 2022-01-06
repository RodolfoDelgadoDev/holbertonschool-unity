using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

///<summary> Main menu script to play the game, quit the game and set colorblind mode</summary>
public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    private Color colorTrap;
    private Color colorGoal;
    
   public void PlayMaze()
   {
        SceneManager.LoadScene("maze");
   }

    private void Update()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        }
        else if (colorblindMode.isOn == false)
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
    }



    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
