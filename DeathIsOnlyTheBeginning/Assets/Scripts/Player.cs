using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Player : MonoBehaviour
{
    public GameObject leftArmSpawn;
    public GameObject rightArmSpawn;
    public GameObject leftLegSpawn;
    public GameObject rightLegSpawn;
    public GameObject headSpawn;

    public Dictionary<string, GameObject> attachments = new Dictionary<string, GameObject>();

    public GameObject leftLegPrefab;
    public GameObject rightLegPrefab;
    public GameObject leftArmPrefab;
    public GameObject rightArmPrefab;
    public GameObject headPrefab;

    NavMeshAgent agent;

    public List<GameObject> parts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // clear Inventory at start
        attachments.Clear();
        parts.Clear();

        // Instantiate Spawner objects
        leftLegSpawn.transform.parent = transform.GetChild(0);
        rightLegSpawn.transform.parent = transform.GetChild(0);
        leftArmSpawn.transform.parent = transform.GetChild(0);
        rightArmSpawn.transform.parent = transform.GetChild(0);
        headSpawn.transform.parent = transform.GetChild(0);     

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.SetDestination(hit.point);
                
            }
        }  
    }

    public void AddToAttachments(string key, GameObject value)
    {
        if (!attachments.ContainsKey(key))
        {
            attachments.Add(key, value);
        }
        else
        {
            Debug.Log("Can't carry more than one of kind " + key);
        }
    }

    public void RemoveFromAttachments(string key)
    {
        if (attachments.ContainsKey(key))
        {
            attachments.Remove(key);
        }
        else {
            Debug.Log("Could not remove " + key);
        }
    }

    public void SpawnHead()
    {
        GameObject head = Instantiate(headPrefab, headSpawn.transform.position, transform.rotation) as GameObject;
        head.transform.parent = headSpawn.transform;
        head.tag = headPrefab.tag;
        parts.Add(head);
    }

    public void SpawnLeftArm()
    {
        GameObject leftArm = Instantiate(leftArmPrefab, leftArmSpawn.transform.position, transform.rotation);
        leftArm.transform.parent = leftArmSpawn.transform;
        leftArm.tag = leftArmPrefab.tag;
        parts.Add(leftArm);
    }

    public void SpawnRightArm()
    {
        // Instantiate rightArm prefab as child of the rightArm Spawner
        GameObject rightArm = Instantiate(rightArmPrefab, rightArmSpawn.transform.position, transform.rotation);
        rightArm.transform.parent = rightArmSpawn.transform;
        rightArm.tag = rightArmPrefab.tag;
        parts.Add(rightArm);
    }
    public void SpawnLeftLeg()
    {
        GameObject leftLeg = Instantiate(leftLegPrefab, leftLegSpawn.transform.position, transform.rotation);
        leftLeg.transform.parent = leftLegSpawn.transform;
        leftLeg.tag = leftLegPrefab.tag;
        parts.Add(leftLeg);
    }

    public void SpawnRightLeg()
    {
        GameObject rightLeg = Instantiate(rightLegPrefab, rightLegSpawn.transform.position, transform.rotation);
        rightLeg.transform.parent = rightLegSpawn.transform;
        rightLeg.tag = rightLegPrefab.tag;
        parts.Add(rightLeg);
    }
}
