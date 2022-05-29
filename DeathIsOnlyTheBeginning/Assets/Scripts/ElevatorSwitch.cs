
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ElevatorSwitch : Switch
{
    public GameObject lever2Spawn;
    public GameObject armPrefab;
    public GameObject dSwitch;
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        GameObject child = transform.GetChild(0).gameObject;
        child.GetComponent<Renderer>().material = activeMat;
        anim = dSwitch.GetComponent<Animation>();

        lever2Spawn.transform.parent = transform.GetChild(0);
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

    /// <summary>
    /// check if the character is in range to interact with the switch
    /// </summary>
    /// <param name="other">the collider entering the collision zone</param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (debugmode || player.attachments.ContainsKey("RightArm") || player.attachments.ContainsKey("LeftArm")))
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

    /// <summary>
    /// The actual interaction logic between player and lever...
    /// </summary>
    void Interact()
    {
        if (!debugmode && armPrefab.tag == "Arm")
        {
            // remove left or right arm from body
            if (player.attachments.ContainsKey("LeftArm"))
            {
                player.RemoveFromAttachments("LeftArm");
                GameObject arm = player.parts.Where(arm => arm.tag == "LeftArm").First();
                int i = player.parts.IndexOf(arm);
                Destroy(arm);
                player.parts.RemoveAt(i);
                Debug.Log("left arm removed");
            }
            else if (player.attachments.ContainsKey("RightArm"))
            {
                player.RemoveFromAttachments("RightArm");
                GameObject arm = player.parts.Where(arm => arm.tag == "RightArm").First();
                int i = player.parts.IndexOf(arm);
                Destroy(arm);
                player.parts.RemoveAt(i);
                Debug.Log("right arm removed");
            }
            else
            {
                Debug.Log("could not remove any arm from attachments");
            }
        }
        anim.Play();
        GameObject armLever = Instantiate(armPrefab, lever2Spawn.transform.position, armPrefab.transform.rotation);
        armLever.transform.parent = lever2Spawn.transform;

        GameObject child = transform.GetChild(0).gameObject;
        child.GetComponent<Renderer>().material = disabledMat;
        isActive = true;
    }
}
