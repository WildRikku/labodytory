using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Switch : MonoBehaviour
{
    public bool debugmode = false;
    public bool isActive = false;
    protected bool interactionPossible = false;

    public Player player;

    public Material disabledMat;
    public Material activeMat;
    public GameObject useTextPrefab;
    protected GameObject objuseText;

    public delegate void SwitchUsedHandler(object sender, bool active);
    public event SwitchUsedHandler SwitchUsedEvent;

    protected void invokeEvent(object sender, bool active)
    {
        try
        {
            SwitchUsedEvent.Invoke(sender, active);
        }
        catch { }
    }

    protected void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + new Vector3(0.0f, -0.5f, 0), Quaternion.Euler(40f, 270f, 0f));
        }
    }
    protected void DestroyUseText()
    {
        if (objuseText)
        {
            Destroy(objuseText);
            objuseText = null;
        }
    }
}
public class DoorSwitch : Switch
{
    public GameObject leverSpawn;
    public GameObject armPrefab;
    public GameObject dSwitch;

    Animation anim;



    // Start is called before the first frame update
    void Start()
    {
        GameObject child = transform.GetChild(0).gameObject;
        child.GetComponent<Renderer>().material = activeMat;
        anim = dSwitch.GetComponent<Animation>();

        leverSpawn.transform.parent = transform.GetChild(0);
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
        if (other.tag == "Player" && (debugmode || (player.attachments.ContainsKey("RightArm") || player.attachments.ContainsKey("LeftArm"))))
        {
            interactionPossible = true;
            ShowUseText();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
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

        anim.Play("pullLever");
        GameObject armLever = Instantiate(armPrefab, leverSpawn.transform.position, armPrefab.transform.rotation);
        armLever.transform.parent = leverSpawn.transform;
        GameObject child = transform.GetChild(0).gameObject;
        child.GetComponent<Renderer>().material = disabledMat;

        //child.GetComponent<AudioSource>().Play();

        isActive = true;
    }
}
