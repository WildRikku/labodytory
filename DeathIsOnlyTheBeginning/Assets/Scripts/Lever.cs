using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    // can be set from outside to generate already active levers/fuses
    public bool isActive = false;

    Collider coll = new Collider();
    // Reference to the player Object
    public Player player;
    // Materials inorder to change the look of the interacted object
    public Material activeMat;
    public Material disabledMat;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        // On start, check if the lever is already active or not 
        if (!isActive)
        {
            GameObject child = transform.GetChild(0).gameObject;
            child.GetComponent<Renderer>().material = disabledMat;
        }

        else
        {
            GameObject child = transform.GetChild(0).gameObject;
            child.GetComponent<Renderer>().material = activeMat;
        }  
    }

    /// <summary>
    /// Check if the character entered the collider, inorder to be able to interact with the doorswitch
    /// </summary>
    /// <param name="other">The collider entering the Collision-zone</param>
    public void OnTriggerStay(Collider other)
    {
        if(other == player.GetComponent<Collider>())
        {
            if((player.attachments["rightArm"] != null || player.attachments["leftArm"] != null) && !isActive)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    isActive = true;
                    GameObject child = transform.GetChild(0).gameObject;
                    child.GetComponent<Renderer>().material = activeMat;
                }
                
            }
            else
            {
                if (Input.GetKey(KeyCode.E))
                    Debug.Log("...");
            }
        }        
    }
}
