using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleAnimate : MonoBehaviour
{
    public Switch activatingSwitch;
    float timer = 0;
    float nextTimer = 0;
    Renderer myRenderer;
    public Material disabledMat;
    public Material activeMat;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Swap materials between red and green
        if (activatingSwitch.isActive)
        {
            if (timer < nextTimer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                // Reset timer
                timer = 0;
                nextTimer = Random.Range(1, 3);
                Material[] currentlyAssignedMaterials = myRenderer.materials;
                float randomMatDecision = Random.Range(0f, 1f);
                if (randomMatDecision > 0.5)
                {
                    currentlyAssignedMaterials[1] = activeMat;
                    GetComponent<AudioSource>().Play();
                }
                else
                {
                    currentlyAssignedMaterials[1] = disabledMat;
                    GetComponent<AudioSource>().Play();
                }
                myRenderer.materials = currentlyAssignedMaterials;
            }
        }
    }
}
