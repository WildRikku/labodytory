using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
    public bool isActive = false;
}
public class DoorSwitch : Switch
{
    
    public bool hasPower = false;
    bool interactionPossible = false;

    public Player player;

    public Material disabledMat;
    public Material activeMat;

    public GameObject lever;
    public GameObject leverSpawn;
    public GameObject armPrefab;
    public GameObject dSwitch;

    Animation anim;

    Lever fuse;

    public delegate void SwitchUsedHandler(object sender, bool active);
    public event SwitchUsedHandler SwitchUsedEvent;

    public GameObject useTextPrefab;
    private GameObject objuseText;

    // Start is called before the first frame update
    void Start()
    {

        fuse = lever.GetComponent<Lever>();


        GameObject child = transform.GetChild(0).gameObject;
        child.GetComponent<Renderer>().material = activeMat;
        anim = dSwitch.GetComponent<Animation>();

        leverSpawn.transform.parent = transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        // check if the switch is powered
        if (fuse.isActive)
        {
            hasPower = true;
        }
        // get Key needs to be in Update always!!
        if (Input.GetKey(KeyCode.E) && interactionPossible)
        {
            Interact();
            interactionPossible = false;

            DestroyUseText();
        }

    }

    /// <summary>
    /// check if the character is in range to interact with the switch
    /// </summary>
    /// <param name="other">the collider entering the collision zone</param>
    public void OnTriggerEnter(Collider other)
    {
        if (hasPower)
        {
            if (other.tag == "Player" && (player.attachments.ContainsKey("RightArm") || player.attachments.ContainsKey("LeftArm")))
            {
                interactionPossible = true;
                ShowUseText();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        DestroyUseText();
        interactionPossible = false;
    }


    void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + new Vector3(0.0f, -0.5f, 0), Quaternion.Euler(40f, 270f, 0f));
        }
    }
    void DestroyUseText()
    {
        if (objuseText)
        {
            Destroy(objuseText);
            objuseText = null;
        }
    }

    /// <summary>
    /// The actual interaction logic between player and lever...
    /// </summary>
    void Interact()
    {
        try
        {
            player.RemoveFromAttachments(armPrefab.tag);
            anim.Play("pullLever");
            if (armPrefab.tag == "RightArm")
                Destroy(player.rightArmPrefab);
            else if (armPrefab.tag == "LeftArm")
                Destroy(player.leftArmPrefab);
            armPrefab = Instantiate(armPrefab, leverSpawn.transform.position, armPrefab.transform.rotation);
            armPrefab.transform.parent = leverSpawn.transform;
            GameObject child = transform.GetChild(0).gameObject;
            child.GetComponent<Renderer>().material = disabledMat;
        }
        catch { }
        isActive = true;
        SwitchUsedEvent.Invoke(this, true);
    }
}
