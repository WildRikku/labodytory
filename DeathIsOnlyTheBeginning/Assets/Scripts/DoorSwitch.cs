using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public bool isActive = false;
    public bool hasPower = false;

    public Player player;

    public Material disabledMat;
    public Material activeMat;

    public GameObject lever;
    public GameObject leverSpawn;
    public GameObject rightArmPrefab;
    public GameObject dSwitch;
    Animation anim;

    Lever fuse;

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
    }

    /// <summary>
    /// check if the character is in range to interact with the switch
    /// </summary>
    /// <param name="other">the collider entering the collision zone</param>
    public void OnTriggerStay(Collider other)
    {
        if (hasPower)
        {
            if (other.tag == "Player" && player.attachments["RightArm"] != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isActive = true;
                    player.RemoveFromAttachments("rightArm");
                    anim.Play("PullLever");
                    rightArmPrefab = Instantiate(rightArmPrefab, leverSpawn.transform.position, rightArmPrefab.transform.rotation);
                    rightArmPrefab.transform.parent = leverSpawn.transform;

                    Destroy(player.rightArmPrefab);

                }
            }     
        }    
    }
}
