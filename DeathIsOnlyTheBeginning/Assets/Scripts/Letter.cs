using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public Player player;

    public bool canOpen = false;
    private bool isOpen = false;
    public Vector3 offsetPosition;

    public GameObject useTextPrefab;
    private GameObject objuseText = null;
    

    public GameObject panel;
    public GameObject canvas;
    public Sprite letterImage;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.E) && (canOpen==true) && (timer>=0.5))
        {
            timer = 0;

            if (isOpen == false)
            {
                ShowImage();
                Destroy(objuseText);
            }
            else
            {
                CloseImage();
            }
        }
        timer += Time.deltaTime; 
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
        isOpen = false;
        CloseImage();
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
        canvas.GetComponent<Canvas>().enabled = true;
        isOpen = true;
    }

    public void CloseImage()
    {
        panel.GetComponent<Image>().sprite = letterImage;
        canvas.GetComponent<Canvas>().enabled = false;
        isOpen = false;
    }
}
