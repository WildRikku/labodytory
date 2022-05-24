using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLight : MonoBehaviour
{

    public bool isActive = false;
    public bool hasPower = false;

    public DoorSwitch doorSwitch;

    public Material activeMat;
    public Material disabledMat;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = disabledMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (doorSwitch.isActive)
        {
            hasPower = true;
        }

        if (hasPower)
        {
            GetComponent<Renderer>().material = activeMat;
        }
    }


}
