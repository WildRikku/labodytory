using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform playerJig;

    public float minFOV;
    public float maxFOV;
    public float sensitivity;
    public float FOV;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        FOV = Camera.main.fieldOfView;
        FOV += (Input.GetAxis("Mouse ScrollWheel") * sensitivity) * -1;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        Camera.main.fieldOfView = FOV;

        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(playerJig.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(playerJig.position, -Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}
