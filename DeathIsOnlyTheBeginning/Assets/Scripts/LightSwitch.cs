using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public List<Light> lights;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<DoorSwitch>().isActive)
        {
            foreach (Light light in lights)
            {
                light.intensity = 10;
            }
        }
        // else block is commented out because we have no mechanism to deactivate the switch again
        // else
        // {
        //     foreach (Light light in lights)
        //     {
        //         light.intensity = 0;
        //     }
        // }
    }
}
