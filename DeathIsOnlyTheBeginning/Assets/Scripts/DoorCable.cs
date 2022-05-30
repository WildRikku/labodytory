using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCable : MonoBehaviour
{

    public bool isActive;

    public Switch lever;

    public Material activeMat;
    public Material disabledMat;

    public void Start()
    {
        if (isActive)
            GetComponent<Renderer>().material = activeMat;
        else
            GetComponent<Renderer>().material = disabledMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (lever != null && lever.isActive)
        {
            isActive = true;
            GetComponent<Renderer>().material = activeMat;
        }
    }
}
