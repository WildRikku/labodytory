using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{

    public ElevatorCable powerLine;
    public bool opened = false;
    public bool inFront = false;
    bool trig = false;
    public Material activeMat;
    
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(powerLine.isActive && !trig) {
            GetComponent<Renderer>().material = activeMat; // Leuchte
            trig = true;
        }
        if (powerLine.isActive && !opened && inFront)
        {
            anim.Play("ElevatorOpen");
            
            opened = true;
            GetComponent<AudioSource>().Play();

            // StartCoroutine(Timer(2f));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inFront = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inFront = false;
        }
    }

    IEnumerator Timer(float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;
        }
        yield return null;

    }
}
