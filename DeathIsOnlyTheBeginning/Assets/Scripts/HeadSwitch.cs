using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeadSwitch : Switch
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && interactionPossible)
        {
            interactionPossible = false;
            GetComponent<AudioSource>().Play();
            Interact();
            DestroyUseText();
            base.invokeEvent(this, true);
        }
    }

    void Interact()
    {
        if (!debugmode)
        {
            GameObject head;
            // remove left or right leg from body
            if (player.attachments.ContainsKey("Head"))
            {
                player.RemoveFromAttachments("Head");
                head = player.parts.Where(head => head.tag == "Head").First();
            }
            else
            {
                Debug.Log("could not remove head from attachments");
                return;
            }
            int i = player.parts.IndexOf(head);
            Destroy(head);
            player.parts.RemoveAt(i);
        }
        // show head in fuse
        this.transform.GetChild(0).gameObject.SetActive(true);

        Material[] currentlyAssignedMaterials = GetComponent<Renderer>().materials;
        currentlyAssignedMaterials[1] = activeMat;
        GetComponent<Renderer>().materials = currentlyAssignedMaterials;
        isActive = true;
        interactionPossible = false;
    }

    /// <summary>
    /// check if the character is in range to interact with the switch
    /// </summary>
    /// <param name="other">the collider entering the collision zone</param>
    public void OnTriggerEnter(Collider other)
    {
        if (!isActive && other.tag == "Player" && (debugmode || player.attachments.ContainsKey("Head")))
        {
            interactionPossible = true;
            ShowUseText();
        }
    }

    void OnTriggerExit(Collider other)
    {
        DestroyUseText();
        interactionPossible = false;
    }
}
