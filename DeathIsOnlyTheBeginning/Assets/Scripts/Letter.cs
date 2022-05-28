using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public Player player;

    public bool canOpen = false;
    public Vector3 offsetPosition;

    public GameObject useTextPrefab;
    private GameObject objuseText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.E) && (canOpen==true))
        {
            ShowImage();
            Destroy(objuseText);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShowUseText();
            canOpen = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        DestroyUseText();
        canOpen = false;
    }

    void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + offsetPosition, Quaternion.Euler(40f, 270f, 0f));
            objuseText.GetComponent<TextMesh>().text = "<E> to read";
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


    public void ShowImage()
    {
        Debug.Log("test");
    }
}
