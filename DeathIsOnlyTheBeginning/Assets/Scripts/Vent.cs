using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        if (inPosition && player.parts.Count > 0)
        {
            // we need to clear all attachments from the player in order to use the vent system.
            foreach (GameObject g in player.parts)
            {
                // alles ablegen 
                Destroy(g);
                player.RemoveFromAttachments(g.tag);
                canVent = true;
            }
        }
        // if player has no attachments we can vent easily
        else if (inPosition && player.parts.Count == 0)
        {
            canVent = true;
        }
        // teleport through the vent depending on the current position
        if (canVent && Input.GetKey(KeyCode.E))
        {
            canVent = false;
            player.GetComponent<NavMeshAgent>().Warp(new Vector3(location.x, player.transform.position.y, location.z));
            StartCoroutine(Vented());
        }

    }

    private IEnumerator Vented()
    {
        inPosition = false;


        yield return new WaitForSeconds(1.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Vector3.Distance(smallSpawn.transform.position, player.transform.position) < Vector3.Distance(largeSpawn.transform.position, player.transform.position))
            {
                Debug.Log("Destination = largeSpawn");
                location = largeSpawn.transform.position;
                inPosition = true;
            }
            else if (Vector3.Distance(smallSpawn.transform.position, player.transform.position) > Vector3.Distance(largeSpawn.transform.position, player.transform.position))
            {
                Debug.Log("destination = smallSpawn");
                location = smallSpawn.transform.position;
                inPosition = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inPosition = false;
        }
    }
}
