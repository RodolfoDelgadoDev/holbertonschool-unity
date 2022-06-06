using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// PlaneSelection class to slect a plane
    /// </summary>
    public class PlaneSelection : MonoBehaviour
    {
        private Renderer _renderer;
        public GameObject Casps;
        private bool check = true;

        // Start is called before the first frame update
        void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        /// <summary>
        /// OnMouseDown to check when a plane it's pressed
        /// </summary>
        public void OnMouseDown()
        {
            if (this.tag == "floor" && check == true)
            {
                check = false;
                _renderer.material.color = Color.gray;
                Renderer[] renderers = FindObjectsOfType<Renderer>();
                GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>().enabled = false;
                foreach (Renderer rd in renderers)
                {
                    var itsme = rd == _renderer;
                    rd.gameObject.SetActive(itsme);
                    if (itsme)
                        rd.GetComponent<PlaneSelection>().enabled = false;
                }
                //GameObject.Find("AR Session Origin").GetComponent<PlaceOnPlane>().enabled = true;
                var canvasUI = GameObject.Find("Canvas");
                canvasUI.transform.Find("Panel").gameObject.SetActive(false);
                canvasUI.transform.Find("StartButton").gameObject.SetActive(true);
                this.GetComponent<PlaneSelection>().enabled = false;
                //this.transform.Find("Targets").gameObject.SetActive(true);
            }
        }

    }
}