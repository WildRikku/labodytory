using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BodyScanner : MonoBehaviour
{
    public Player player;
    bool opened = false;
    NavMeshAgent playerAgent;
    public CameraShake shakeCamera;
    public Light scanLight;
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        playerAgent = player.GetComponent<NavMeshAgent>();
        anim = GameObject.Find("obj_scanner_door").GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!opened && other.tag == "Player")
        {
            StartCoroutine(scanPlayer());
        }
    }

    void OnTriggerExit(Collider other)
    {
                
    }

    IEnumerator scanPlayer()
    {
        scanLight.enabled = true;
        playerAgent.isStopped = true;
        yield return new WaitForSeconds(2f);
        playerAgent.isStopped = false;
        if (player.attachments.ContainsKey("RightArm") && player.attachments.ContainsKey("LeftArm") && player.attachments.ContainsKey("RightLeg") && player.attachments.ContainsKey("LeftLeg") && player.attachments.ContainsKey("Head"))
        {
            // TODO magic level completed
            scanLight.color = new Color(47.0f/255, 132.0f/255, 41.0f/255, 1);
            Debug.Log("all parts present");
            opened = true;
            anim.Play("BodyScannerDoor");
        }
        else
        {
            // kick player out
            playerAgent.updateRotation = false;
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
            float oldSpeed = playerAgent.speed;
            float oldAccel = playerAgent.acceleration;
            playerAgent.speed = 500;
            playerAgent.acceleration = 500;
            StartCoroutine(shakeCamera.Shake(.5f, .3f));
            playerAgent.SetDestination(new Vector3(11.5f, 1.215f, 3.878f));
            playerAgent.SetDestination(player.transform.position + new Vector3(-3, 0, 0));
            yield return new WaitForSeconds(.5f);
            playerAgent.updateRotation = true;
            playerAgent.speed = oldSpeed;
            playerAgent.acceleration = oldAccel;
            scanLight.enabled = false;
        }
    }
}
