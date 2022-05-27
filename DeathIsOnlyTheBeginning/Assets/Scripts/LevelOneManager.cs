using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneManager : MonoBehaviour
{
    public ElevatorCable cable;
    public Elevator elevator;

    bool logged = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cable.isActive && elevator.trig && elevator.inFront)
        {
            // Load next Scene here!
            if (!logged)
            {
                Debug.Log("Level completed. Press Space to continue...");
                logged = true;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
