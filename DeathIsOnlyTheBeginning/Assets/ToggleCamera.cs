using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    public GameObject cameraToToggle;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Switch>().SwitchUsedEvent += HandleSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleSwitch(object switchObject, bool active) {
        cameraToToggle.GetComponent<Animator>().enabled = !cameraToToggle.GetComponent<Animator>().enabled;
        cameraToToggle.transform.GetChild(0).gameObject.SetActive(cameraToToggle.GetComponent<Animator>().enabled);
    }
}
