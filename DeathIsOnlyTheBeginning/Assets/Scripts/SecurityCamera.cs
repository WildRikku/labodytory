using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;  

public class SecurityCamera : MonoBehaviour
{

    public bool playerCaught = false;
    public Material caughtMaterial;

    private List<SecurityCamera> _cameraScripts = new List<SecurityCamera>();
    private List<Animator> _animList = new List<Animator>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] _cones = GameObject.FindGameObjectsWithTag("CameraCone");
        foreach (GameObject cone in _cones)
        {
            SecurityCamera _script = cone.GetComponent<SecurityCamera>();

            if (_script != null)
            {
                _cameraScripts.Add(_script);
            }
        }

        GameObject[] _cameras = GameObject.FindGameObjectsWithTag("Camera1");
        foreach (GameObject camera in _cameras)
        {
            Animator _anim = camera.GetComponent<Animator>();

            if (_anim != null)
            {
                _animList.Add(_anim);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCaught)
        {
            StartCoroutine(GameOverRoutine());
        }
    }


    public void PlayerCaught()
    {
        playerCaught = true;
    }

    private IEnumerator GameOverRoutine()
    {
        playerCaught = false;
        DisableAnimator();
        GameObject.Find("Player").GetComponent<NavMeshAgent>().isStopped = true;
        // reload scene
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DisableAnimator()
    {
        foreach (Animator anim in _animList)
        {
            anim.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (SecurityCamera script in _cameraScripts)
            {
                script.PlayerCaught();
            }
            // anschlie�end noch die renderer color auf rot setzen?
            // GameObject child = transform.GetChild(0).gameObject;
            GetComponent<Renderer>().material = caughtMaterial;
            Debug.Log("You have been spotted...");
        }
    }
}
