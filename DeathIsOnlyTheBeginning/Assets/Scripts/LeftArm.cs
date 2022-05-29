using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    public Player player;
    public GameObject arm;

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
            GrabArm();
            canGrab = false;
            Destroy(gameObject);
            Destroy(objuseText);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
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
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + new Vector3(0.0f, -0.5f, 0), Quaternion.Euler(40f, 270f, 0f));
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


    public void GrabArm()
    {
        player.AddToAttachments(this.tag, arm);
        if (tag == "LeftArm")
            player.SpawnLeftArm();
        
    }
}
