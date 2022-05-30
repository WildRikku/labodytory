using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCamera : MonoBehaviour
{
    public GameObject camera;

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
        camera.GetComponent<Animator>().enabled = !camera.GetComponent<Animator>().enabled;
        camera.transform.GetChild(0).gameObject.SetActive(camera.GetComponent<Animator>().enabled);
    }
}
