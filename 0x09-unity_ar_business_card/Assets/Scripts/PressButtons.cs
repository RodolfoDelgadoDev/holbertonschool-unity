using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// PressButtons class
/// </summary>
public class PressButtons : MonoBehaviour
{
    /// <summary>
    /// array of gameobjects pressed buttons
    /// </summary>
    public GameObject[] pressedButtons;

    /// <summary>
    /// AudioSource of gameobject
    /// </summary>
    public AudioSource source;

    /// <summary>
    /// buttonName
    /// </summary>
    string buttonName;
   
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
                {
                    buttonName = Hit.transform.name;
                switch(buttonName)
                {
                    case "twitter":
                        source.Play();
                        pressedButtons[3].SetActive(true);
                        pressedButtons[3].SetActive(false);
                        Application.OpenURL("https://twitter.com/DR08s");
                        break;
                    case "github":
                        source.Play();
                        pressedButtons[2].SetActive(true);
                        pressedButtons[2].SetActive(false);
                        Application.OpenURL("https://github.com/Ro8s");
                        break;
                    case "linkedin":
                        source.Play();
                        pressedButtons[1].SetActive(true);
                        pressedButtons[1].SetActive(false);
                        Application.OpenURL("https://www.linkedin.com/in/rodolfo-delgado-alonso/");
                        break;
                    case "email":
                        source.Play();
                        string email = "rodolfo.delgadodev@gmail.com";
                        string subject = MyEscapeURL("Contact");
                        string body = MyEscapeURL("Hello");
                        pressedButtons[0].SetActive(true);
                        pressedButtons[0].SetActive(false);
                        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
                        break;
                    default:
                        break;
                }
                }
        }
    }
    /// <summary>
    /// MyEscapeURL method
    /// </summary>
    /// <param name="url">url</param>
    /// <returns>string</returns>
    string MyEscapeURL(string url)
    {
        return UnityWebRequest.EscapeURL(url).Replace("+", "%20");
    }



}

