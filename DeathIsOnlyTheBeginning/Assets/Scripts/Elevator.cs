using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public ElevatorCable powerLine;
    bool opened = false;
    bool inFront = false;
    public bool trig = false;
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
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inFront = true;
        }
    }
}
