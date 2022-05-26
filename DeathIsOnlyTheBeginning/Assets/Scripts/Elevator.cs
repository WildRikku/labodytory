using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{

    public ElevatorCable powerLine;
    bool opened = false;
    bool inFront = false;
    public bool trig = false;
    public CameraShake cameraShake;
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerLine.isActive && !opened && inFront)
        {
            anim.Play("ElevatorOpen");
            trig = true;
            opened = !opened;

            StartCoroutine(cameraShake.Shake(.3f, .15f));
            StartCoroutine(Timer(2f));
            Debug.Log("Press Space for next Level");

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(2);
            }
        }
        
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            inFront = true;
        }
    }

    IEnumerator Timer(float duration)
    {
        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            
            elapsed += Time.deltaTime; 
        }
        yield return null;
        
    }
}
