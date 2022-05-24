using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    public Player player;
    public GameObject arm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                player.AddToAttachments(this.tag, arm);
                player.SpawnRightArm();
                Destroy(this.gameObject);
            }
        }
    }
}
