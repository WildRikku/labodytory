using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Player player;
    public GameObject head;

    bool canGrab = false;

    public GameObject useTextPrefab;
    private GameObject objuseText;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.E) && canGrab)
        {
            GrabHead();
            canGrab = false;
            Destroy(gameObject);
            Destroy(objuseText);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && (!player.attachments.ContainsKey("Head")))
        {
            ShowUseText();
            canGrab = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        DestroyUseText();
        canGrab = false;
    }

    void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + new Vector3(0.0f, -0.5f, 0), Quaternion.Euler(90f, 270f, 0f));
            objuseText.GetComponent<TextMesh>().text = "<E> to grab";
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


    public void GrabHead()
    {
        player.AddToAttachments(this.tag, head);
        if (tag == "Head")
            player.SpawnHead();
        
    }
}
