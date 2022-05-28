using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorArrival : MonoBehaviour
{
    public Light shakelight;
    public CameraShake cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ElevatorSwitch>().FuseUsedEvent += HandleFuse;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleFuse(object sender, bool active)
    {
        if (active)
        {
            StartCoroutine(elevatorArrive());
        }
    }

    IEnumerator elevatorArrive()
    {
        // shake screen
        yield return new WaitForSeconds(1);
        StartCoroutine(cameraShake.Shake(.3f, .15f));
        yield return new WaitForSeconds(.3f);
        // shake light
        shakelight.intensity = 0;
        yield return new WaitForSeconds(.7f);
        shakelight.intensity = 10;
    }
}
