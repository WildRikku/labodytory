using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public List<Light> lights;
    public bool unstableLight = true;
    bool active = false;
    float timer = 0;
    float nextBlink;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Switch>() != null)
        {
            GetComponent<Switch>().SwitchUsedEvent += HandleSwitch;
        }
        nextBlink = 10.0f + System.Convert.ToSingle(System.Math.Floor(Random.value * 10.0f));
    }

    // Update is called once per frame
    void HandleSwitch(object sender, bool active)
    {
        Debug.Log("Light handling");
        this.active = active;
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
            light.enabled = false;
            // random duration of short blink
            yield return new WaitForSeconds(0.075f + Random.value * 0.075f);
            light.enabled = true;
            yield return new WaitForSeconds(0.075f + Random.value * 0.075f);
        }
        // one long blink with random duration
        light.enabled = false;
        yield return new WaitForSeconds(0.25f + Random.value * 0.5f);
        light.enabled = true;
    }

    IEnumerator waitAndTurnLightOn(Light light, float seconds)
    {
        light.enabled = false;
        yield return new WaitForSeconds(seconds);
        StartCoroutine(turnLightOn(light));
    }

    void Update()
    {
        // make random lights turn off and back on randomly
        if (active && unstableLight)
        {
            if (timer < nextBlink)
            {
                timer += Time.deltaTime;
            }
            else
            {
                int lightNr = System.Convert.ToInt32(System.Math.Floor(Random.value * lights.Count - 0.01f));
                // lights[lightNr].intensity = 0;
                StartCoroutine(waitAndTurnLightOn(lights[lightNr], System.Convert.ToSingle(System.Math.Ceiling(Random.value * 5.0f))));
                nextBlink = 10.0f + System.Convert.ToSingle(System.Math.Floor(Random.value * 10.0f));
                timer = 0;
            }
        }
    }
}