using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;

    public float minFOV;
    public float maxFOV;
    public float sensitivity;
    public float FOV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (target.position + offset);

        FOV = Camera.main.fieldOfView;
        FOV += (Input.GetAxis("Mouse ScrollWheel") * sensitivity) * -1;
        FOV = Mathf.Clamp(FOV, minFOV, maxFOV);
        Camera.main.fieldOfView = FOV;
    }
}
