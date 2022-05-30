using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Leg : MonoBehaviour
{
    public Player player;
    public GameObject leg;

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
            GrabLeg();
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

    public abstract void GrabLeg();
}
public class LeftLeg : Leg
{
    public override void GrabLeg()
    {
        player.AddToAttachments(this.tag, leg);
        if (tag == "LeftLeg")
        {
            player.SpawnLeftLeg();
        }
    }
}