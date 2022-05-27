using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    public Player player;
    public GameObject arm;

    bool canGrab = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.E) && canGrab)
        {
            GrabArm();
            canGrab = false;
            Destroy(gameObject);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" )
        {
            canGrab = true;
        }
    }

    public void GrabArm()
    {
        player.AddToAttachments(this.tag, arm);
        if (tag == "LeftArm")
            player.SpawnLeftArm();
        
    }
}
