using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vent : MonoBehaviour
{
    public Transform smallSpawn;
    public Transform largeSpawn;
    public Player player;
    bool inPosition = false;
    Vector3 location;
    public GameObject useTextPrefab;
    private GameObject objuseText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inPosition && Input.GetKey(KeyCode.E))
        {
            if (player.parts.Count > 0)
            {
                // we need to clear all attachments from the player in order to use the vent system.
                for (int i = player.parts.Count - 1; i >= 0; i--)
                {
                    player.RemoveFromAttachments(player.parts[i].tag);
                    Destroy(player.parts[i]);
                    player.parts.RemoveAt(i); // remove the slot that now contains null
                }
            }
            player.GetComponent<NavMeshAgent>().Warp(new Vector3(location.x, player.transform.position.y, location.z));
            StartCoroutine(Vented());
        }
    }

    private IEnumerator Vented()
    {
        inPosition = false;


        yield return new WaitForSeconds(1.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Vector3.Distance(smallSpawn.transform.position, player.transform.position) < Vector3.Distance(largeSpawn.transform.position, player.transform.position))
            {
                Debug.Log("Destination = largeSpawn");
                location = largeSpawn.transform.position;
                inPosition = true;
            }
            else if (Vector3.Distance(smallSpawn.transform.position, player.transform.position) > Vector3.Distance(largeSpawn.transform.position, player.transform.position))
            {
                Debug.Log("destination = smallSpawn");
                location = smallSpawn.transform.position;
                inPosition = true;
            }
            ShowUseText();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inPosition = false;
            DestroyUseText();
        }
    }

    void ShowUseText()
    {
        if (useTextPrefab != null && objuseText == null)
        {
            objuseText = GameObject.Instantiate(useTextPrefab, transform.position + new Vector3(0.0f, -0.5f, 0), Quaternion.Euler(90f, 270f, 0f));
            objuseText.GetComponent<TextMesh>().text = "<E> to use vent";
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
}
