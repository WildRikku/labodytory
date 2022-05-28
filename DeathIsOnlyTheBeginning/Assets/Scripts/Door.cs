using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool canOpen = true;

    public Switch doorSwitch;
    public float rotSpeed = 10.0f;

    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (canOpen && doorSwitch != null && doorSwitch.isActive)
        {
            anim.Play("OpenDoor");
           
            canOpen = false;
        }
    }
}
