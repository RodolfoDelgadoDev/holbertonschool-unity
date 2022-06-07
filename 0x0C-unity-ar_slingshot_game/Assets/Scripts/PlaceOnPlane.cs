using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;

        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }
        /// <summary>
        /// Camera
        /// </summary>
        public Camera cam;

        private ARPlaneManager planeManager;

        private bool firstCheck = true;


        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject0 { get; private set; }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject1 { get; private set; }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject2 { get; private set; }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject3 { get; private set; }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        public GameObject spawnedObject4 { get; private set; }


        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
            planeManager = GetComponent<ARPlaneManager>();
        }

        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }

            touchPosition = default;
            return false;
        }

        void Update()
        {
            if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    if (hitInfo.collider.tag == "floor" && firstCheck)
                    {
                        hitInfo.collider.gameObject.GetComponent<Renderer>().material.color = Color.clear;

                        firstCheck = false;
                    }
                }

                    
                if (spawnedObject0 == null)
                {
                    spawnedObject0 = Instantiate(m_PlacedPrefab, hitInfo.collider.gameObject.transform.position + new Vector3(0f,0.1f,0f), hitInfo.collider.gameObject.transform.rotation);
                    spawnedObject1 = Instantiate(m_PlacedPrefab, hitInfo.collider.gameObject.transform.position + new Vector3(-0.5f, 0.1f, -0.5f), hitInfo.collider.gameObject.transform.rotation);
                    spawnedObject2 = Instantiate(m_PlacedPrefab, hitInfo.collider.gameObject.transform.position + new Vector3(0.5f, 0.1f, -0.5f), hitInfo.collider.gameObject.transform.rotation);
                    spawnedObject3 = Instantiate(m_PlacedPrefab, hitInfo.collider.gameObject.transform.position + new Vector3(0.5f, 0.1f, 0f), hitInfo.collider.gameObject.transform.rotation);
                    spawnedObject4 = Instantiate(m_PlacedPrefab, hitInfo.collider.gameObject.transform.position + new Vector3(-0.5f, 0.1f, 0.5f), hitInfo.collider.gameObject.transform.rotation);

                    foreach (var plane in planeManager.trackables)
                    {
                        if (plane.gameObject.GetComponent<Renderer>().material.color != Color.clear)
                        plane.gameObject.SetActive(false);
                    }
                    
                    planeManager.enabled = false;
                    var canvasUI = GameObject.Find("Canvas");
                    canvasUI.transform.Find("Panel").gameObject.SetActive(false);
                    canvasUI.transform.Find("StartButton").gameObject.SetActive(true);
                }
                //else
                //{
                  //  spawnedObject.transform.position = hitPose.position;
                //}
            }
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}