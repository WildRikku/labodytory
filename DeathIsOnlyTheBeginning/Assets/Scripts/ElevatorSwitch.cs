
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSwitch : MonoBehaviour
{
    public bool isActive = false;
    bool interactionPossible = false;

    public Player player;

    public Material disabledMat;
    public Material activeMat;

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
            Interact();
            interactionPossible = false;

        }

    }

    /// <summary>
    /// check if the character is in range to interact with the switch
    /// </summary>
    /// <param name="other">the collider entering the collision zone</param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (player.attachments.ContainsKey("RightArm") || player.attachments.ContainsKey("LeftArm")))
        {
                interactionPossible = true;   
        }
    }


    /// <summary>
    /// The actual interaction logic between player and lever...
    /// </summary>
    void Interact()
    {

        player.RemoveFromAttachments(armPrefab.tag);
        anim.Play("PullElevatorSwitch");
        if (armPrefab.tag == "LeftArm")
            Destroy(player.leftArmPrefab);
        armPrefab = Instantiate(armPrefab, lever2Spawn.transform.position, armPrefab.transform.rotation);
        armPrefab.transform.parent = lever2Spawn.transform;

        isActive = true;
        GameObject child = transform.GetChild(0).gameObject;
        child.GetComponent<Renderer>().material = disabledMat;
    }
}
