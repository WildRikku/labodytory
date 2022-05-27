using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public List<Light> lights;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DoorSwitch>().SwitchUsedEvent += HandleSwitch;
    }

    // Update is called once per frame
    void HandleSwitch(object sender, bool active)
    {
        if (active)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                // this is necessary because WaitForSeconds does not allow methods it is called from to return void
                StartCoroutine(turnLightOn(lights[i]));
            }
        }
    }

    IEnumerator turnLightOn(Light light)
    {
        // random number of short blinks
        int count = 2 + System.Convert.ToInt16(System.Math.Floor(Random.value * 3));
        for (short s = 0; s < count; s++)
        {
            light.intensity = 0;
            // random duration of short blink
            yield return new WaitForSeconds(0.075f + Random.value * 0.075f);
            light.intensity = 10;
            yield return new WaitForSeconds(0.075f + Random.value * 0.075f);
        }
        // one long blink with random duration
        light.intensity = 0;
        yield return new WaitForSeconds(0.25f + Random.value * 0.3f);
        light.intensity = 10;
    }


    void Update()
    {

    }
}