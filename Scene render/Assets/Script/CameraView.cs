using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    float MouseSensitivity = 20;
    float xRotation = 0;
    public Transform playerView;
    public Transform playerBody;
    public Camera cam;
    float FOV;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        FOV = cam.fieldOfView;
    }

    // Update is called once per frame

    void Update()
    {

            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity ;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity ;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -75, 75);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);

        FOV = cam.fieldOfView;

        if (Input.GetMouseButtonDown(1))
        {
            FOV += 40;
        }

        
    

    }
}
