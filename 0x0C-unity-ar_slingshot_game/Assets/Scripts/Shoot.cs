using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Shoot class that defines the shooting of the ball
/// </summary>
public class Shoot : MonoBehaviour
{

    private Vector3 mOffset;
    private float mZCoord;

    /// <summary>
    /// center gameObject
    /// </summary>
    public GameObject center;

    private Rigidbody rb;

    private bool isShooting = false;

    /// <summary>
    /// Line trayectory of the ball
    /// </summary>
    public LineRenderer Trajectory;

    private AudioSource audioSource;

    /// <summary>
    /// ListOfAudioClips
    /// </summary>
    public AudioClip[] audioClips;

    /// <summary>
    /// TextScore
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// ammoCounter of the panel
    /// </summary>
    public GameObject[] ammoCounter;

    private int i = 0;

    private bool colFloor = false;

    private bool colTarget = false;

    private Vector3 startPosition;

    private List<GameObject> hittedTargets;


    /// <summary>
    /// PlayAgainButton
    /// </summary>
    public GameObject PlayAgainButton;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        startPosition = this.transform.localPosition;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
        float pullDistance = Vector3.Distance(center.transform.position, GetMouseWorldPos());
        ShowTrajectory(pullDistance);
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = transform.position - GetMouseWorldPos();

    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mosePoint = Input.mousePosition;
        mosePoint.z = mZCoord;
        var result = Camera.main.ScreenToWorldPoint(mosePoint);
        return result;
    }

    private void OnMouseUp()
    {
        SetTrajectoryActive(false);
        Vector3 result = center.transform.position - GetMouseWorldPos();
        rb.useGravity = true;
        isShooting = true;
        rb.AddForce(result * 7, ForceMode.Impulse);
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    void LateUpdate()
    {
        if (!isShooting)
        {
            Transform target = Camera.main.transform;
            this.transform.parent = target;
        }
        else
        {
            this.transform.parent = null;
            StartCoroutine(WaitingForCol());
        }
    }


    void SetTrajectoryActive(bool active)
    {
        Trajectory.enabled = active;
    }


    void ShowTrajectory(float distance)
    {
        SetTrajectoryActive(true);
        Vector3 diff = center.transform.position - GetMouseWorldPos();
        int segmentCount = 25;
        Vector3[] segments = new Vector3[segmentCount];
        segments[0] = this.transform.position;

        Vector3 segVelocity = new Vector3(diff.x, diff.y, diff.z) * 15 * distance;

        for(int i = 1; i < segmentCount; i++)
        {
            float timeCurve = (i * Time.fixedDeltaTime * 7);
            segments[i] = segments[0] + segVelocity * timeCurve + 0.5f * Physics.gravity * Mathf.Pow(timeCurve, 2);
        }
        Trajectory.positionCount = segmentCount;
        for(int j = 0; j < segmentCount; j++)
        {
            Trajectory.SetPosition(j, segments[j]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();

            var points = int.Parse(scoreText.text) + 10;
            scoreText.text = points.ToString();
            if (i < 6)
                ammoCounter[i].SetActive(false);
            hittedTargets.Add(other.gameObject);
            other.gameObject.SetActive(false);
            colTarget = true;
            rb.useGravity = false;
            
            if (this.transform.parent == null)
            {
                Transform target = Camera.main.transform;
                this.transform.parent = target;
                this.transform.position = startPosition;
            }
            rb.velocity = Vector3.zero;
        }
        else if(other.tag == "floor")
        {
            audioSource.clip = audioClips[2];
            audioSource.Play();
            colFloor = true;
            rb.useGravity = false;
            if (this.transform.parent == null)
            {
                Transform target = Camera.main.transform;
                this.transform.parent = target;
                this.transform.position = startPosition;
            }
            rb.velocity = Vector3.zero;

        }
    }

    IEnumerator WaitingForCol()
    {
        yield return new WaitForSeconds(4f);
        if (!colFloor && !colTarget)
        {
            if (i < 6)
                ammoCounter[i].SetActive(false);
            i++;
            rb.useGravity = false;
            if (this.transform.parent == null)
            {
                Transform target = Camera.main.transform;
                this.transform.parent = target;
                this.transform.position = startPosition;
            }
            audioSource.clip = audioClips[4];
            audioSource.Play();

        }
        else if(i == 6)
        {
            PlayAgainButton.SetActive(true);
        }
        isShooting = false;
        colFloor = false;
        colTarget = false;
        rb.useGravity = false;
        rb.velocity = Vector3.zero;


    }

    /// <summary>
    /// Event when player press playagain
    /// </summary>
    public void OnPlayAgain()
    {
        foreach (var targ in hittedTargets)
        {
            targ.SetActive(true);
        }
        foreach(var am in ammoCounter)
        {
            am.SetActive(true);
        }
        hittedTargets.Clear();
        i = 0;
        audioSource.clip = audioClips[3];
        audioSource.Play();
        PlayAgainButton.SetActive(false);
    }
}
