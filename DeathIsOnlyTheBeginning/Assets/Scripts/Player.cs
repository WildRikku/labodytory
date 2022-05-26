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
    }

    public void SpawnHead()
    {
       
        headPrefab = Instantiate(headPrefab, headSpawn.transform.position, transform.rotation) as GameObject;
        headPrefab.transform.parent = headSpawn.transform;
        parts.Add(headPrefab);
    }

    public void SpawnLeftArm()
    {
        leftArmPrefab = Instantiate(leftArmPrefab, leftArmSpawn.transform.position, transform.rotation);
        leftArmPrefab.transform.parent = leftArmSpawn.transform;
        parts.Add(leftArmPrefab);
    }

    public void SpawnRightArm()
    {
        // Instantiate rightArm prefab as child of the rightArm Spawner
        rightArmPrefab = Instantiate(rightArmPrefab, rightArmSpawn.transform.position, transform.rotation);
        rightArmPrefab.transform.parent = rightArmSpawn.transform;
        parts.Add(rightArmPrefab);
    }
    public void SpawnLeftLeg()
    {
        leftLegPrefab = Instantiate(leftLegPrefab, leftLegSpawn.transform.position, transform.rotation);
        leftLegPrefab.transform.parent = leftLegSpawn.transform;
        parts.Add(leftLegPrefab);
    }

    public void SpawnRightLeg()
    {
        rightLegPrefab = Instantiate(rightLegPrefab, rightLegSpawn.transform.position, transform.rotation);
        rightLegPrefab.transform.parent = rightLegSpawn.transform;
        parts.Add(rightLegPrefab);
    }
}
