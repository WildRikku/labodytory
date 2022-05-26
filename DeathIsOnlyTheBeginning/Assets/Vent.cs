using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public Transform smallSpawn;
    public Transform largeSpawn;
    public Player player;
    bool inPosition = false;
    bool canVent = false;
    Vector3 location;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.parts.Count > 0)
        {
            // we need to clear all attachments from the player in order to use the vent system.
            foreach(GameObject g in player.parts)
            {
                // alles ablegen 
                Destroy(g);
                player.RemoveFromAttachments(g.tag);
                canVent = true;
                inPosition = false;
            }
        }
        // if player has no attachments we can vent easily
        if(inPosition && player.parts.Count == 0)
        {
            canVent = true;
            // teleport through the vent depending on the current position
            if (canVent && Input.GetKey(KeyCode.E))
            {
                player.transform.position = location;
                canVent = false;
                inPosition = false;
            }
        }
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Vector3.Distance(smallSpawn.position, player.transform.position) < Vector3.Distance(largeSpawn.position, player.transform.position))
            {
                location = largeSpawn.position;
                inPosition = true;
            }
            else if (Vector3.Distance(smallSpawn.position, player.transform.position) > Vector3.Distance(largeSpawn.position, player.transform.position))
            {
                location = smallSpawn.position;
                inPosition = true;
            }
        }
    }
}
