using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneManager : MonoBehaviour
{
    public ElevatorCable cable;
    public Elevator elevator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cable.isActive && elevator.trig)
        {
            // Load next Scene here!
            Debug.Log("Level completed. Press E to continue...");

            if (Input.GetKey(KeyCode.E))
                // Load next Level, TODO !!!!!
                Debug.Log("scene load not working...");
        }
    }
}
