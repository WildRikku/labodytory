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
    Vector3 translation;
    float movementDuration = 1;
    float movementTimer = 0;
    bool move = false;
    bool hasMoved = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasMoved && Input.GetKey(KeyCode.E) && interactionPossible && (timer >= 0.5))
        {
            timer = 0;
            interactionPossible = false;
            Interact();
            DestroyUseText();
        }
        else if (!hasMoved)
        {
            timer += Time.deltaTime;
        }
    }

    protected void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + new Vector3(0.0f, -0.5f, 0), Quaternion.Euler(90f, 270f, 0f));
            objuseText.GetComponent<TextMesh>().text = "<E> to move";
        }
    }
    protected void ShowCantUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + new Vector3(0.0f, -0.5f, 0), Quaternion.Euler(90f, 270f, 0f));
            objuseText.GetComponent<TextMesh>().text = "need more bodyparts";
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
        if (!hasMoved && other.tag == "Player" && (debugMode || (player.attachments.ContainsKey("RightArm") && player.attachments.ContainsKey("LeftArm"))))
        {
            interactionPossible = true;
            ShowUseText();
        }
        else
        {
            if (!hasMoved)
                ShowCantUseText();
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        DestroyUseText();
        interactionPossible = false;
    }

    void FixedUpdate()
    {
        if (move && movementTimer < movementDuration)
        {
            transform.position += translation * Time.deltaTime / movementDuration;
            movementTimer += Time.deltaTime;
        }
        else if (move)
        {
            move = false;
            movementTimer = 0;
            hasMoved = true;
        }
    }

    void Interact()
    {
        // freeze player


        // figure out at which side the player stands
        Vector3 renderedSize = GetComponent<Renderer>().bounds.size;

        if (player.transform.position.x < transform.position.x - renderedSize.x / 2)
        {
            translation = new Vector3(0.01f * transform.lossyScale.x, 0, 0);
            move = true;
        }
        else if (player.transform.position.x > transform.position.x + renderedSize.x / 2)
        {
            translation = new Vector3(-0.01f * transform.lossyScale.x, 0, 0);
            move = true;
        }
        else if (player.transform.position.z < transform.position.z - renderedSize.z / 2)
        {
            translation = new Vector3(0, 0, 0.01f * transform.lossyScale.z);
            move = true;
        }
        else if (player.transform.position.z > transform.position.z + renderedSize.z / 2)
        {
            translation = new Vector3(0, 0, -0.01f * transform.lossyScale.z);
            move = true;
        }
    }
}
