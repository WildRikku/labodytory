using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LegFuse : Switch
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // get Key needs to be in Update always!!
        if (Input.GetKey(KeyCode.E) && interactionPossible)
        {
            interactionPossible = false;
            Interact();
            DestroyUseText();
            base.invokeEvent(this, true);
        }
    }

    void Interact()
    {
        if (!debugmode)
        {
            GameObject leg;
            // remove left or right leg from body
            if (player.attachments.ContainsKey("LeftLeg"))
            {
                player.RemoveFromAttachments("LeftLeg");
                leg = player.parts.Where(leg => leg.tag == "LeftLeg").First();
            }
            else if (player.attachments.ContainsKey("RightLeg"))
            {
                player.RemoveFromAttachments("RightLeg");
                leg = player.parts.Where(leg => leg.tag == "RightLeg").First();
            }
            else
            {
                Debug.Log("could not remove any leg from attachments");
                return;
            }
            int i = player.parts.IndexOf(leg);
            Destroy(leg);
            player.parts.RemoveAt(i);
        }
        // show leg in fuse
        this.transform.GetChild(0).gameObject.SetActive(true);

        GetComponent<Renderer>().material = activeMat;
        isActive = true;
        interactionPossible = false;
    }

    /// <summary>
    /// check if the character is in range to interact with the switch
    /// </summary>
    /// <param name="other">the collider entering the collision zone</param>
    public void OnTriggerEnter(Collider other)
    {
        if (!isActive && other.tag == "Player" && (debugmode || player.attachments.ContainsKey("RightLeg") || player.attachments.ContainsKey("LeftLeg")))
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
