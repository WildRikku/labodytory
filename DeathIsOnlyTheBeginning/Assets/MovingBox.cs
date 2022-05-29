using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{
    public GameObject useTextPrefab;
    protected GameObject objuseText;
    bool interactionPossible;
    public Player player;
    public bool debugMode = false;
    float timer; // prevent double key hit

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && interactionPossible&& (timer>=0.5))
        {
            timer = 0;
            interactionPossible = false;
            Interact();
            DestroyUseText();
        }
        timer += Time.deltaTime;
    }

    protected void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + new Vector3(0.0f, -0.5f, 0), Quaternion.Euler(90f, 270f, 0f));
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (debugMode || (player.attachments.ContainsKey("RightArm") && player.attachments.ContainsKey("LeftArm"))))
        {
            Vector3 renderedSize = GetComponent<Renderer>().bounds.size;
            if (player.transform.position.x < transform.position.x - renderedSize.x / 2)
            {
                // transform.Translate(renderedSize.x, 0, 0);
                Debug.Log("in front " + transform.position.x.ToString());
            }
            else if (player.transform.position.x > transform.position.x + renderedSize.x / 2)
            {
                // transform.Translate(-renderedSize.x, 0, 0);
                Debug.Log("in back");
            }
            else if (player.transform.position.z < transform.position.z - renderedSize.z / 2)
            {
                // transform.Translate(renderedSize.z, 0, 0);
                Debug.Log("in right");
            }
            else if (player.transform.position.z > transform.position.z + renderedSize.z / 2)
            {
                // transform.Translate(-renderedSize.z, 0, 0);
                Debug.Log("in left");
            }
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

    void Interact()
    {
        // freeze player


        // figure out at which side the player stands
        Vector3 renderedSize = GetComponent<Renderer>().bounds.size;
        if (player.transform.position.x < transform.position.x - renderedSize.x / 2)
        {
            transform.Translate(renderedSize.x, 0, 0);
            Debug.Log("front " + transform.position.x.ToString());
        }
        else if (player.transform.position.x > transform.position.x + renderedSize.x / 2)
        {
            transform.Translate(-renderedSize.x, 0, 0);
            Debug.Log("back");
        }
        else if (player.transform.position.z < transform.position.z - renderedSize.z / 2)
        {
            transform.Translate(renderedSize.z, 0, 0);
            Debug.Log("right");
        }
        else if (player.transform.position.z > transform.position.z + renderedSize.z / 2)
        {
            transform.Translate(-renderedSize.z, 0, 0);
            Debug.Log("left " + transform.position.x.ToString());
        }
        Debug.Log("moin");
    }
}
