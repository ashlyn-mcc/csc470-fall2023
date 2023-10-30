using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipScript : MonoBehaviour
{

    float forwardSpeed = 500f;

    float xRotationSpeed = 100f;
    float yRotationSpeed = 50f;
    float zRotationSpeed = 100f;

    public GameObject cameraObject;

    Vector3 oldCamPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        float xRotation = vAxis * xRotationSpeed * Time.deltaTime;
        float yRotation = hAxis * yRotationSpeed * Time.deltaTime;
        float zRotation = hAxis * zRotationSpeed * Time.deltaTime;

        transform.Rotate(xRotation, yRotation, -zRotation, Space.Self);

        gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * forwardSpeed;

        Vector3 newCamPos = transform.position + -transform.forward * 200 + Vector3.up * 100;
        
        if (oldCamPos == null)
        {
            oldCamPos = newCamPos;
        }
        cameraObject.transform.position = (newCamPos + oldCamPos) / 2f;
        cameraObject.transform.LookAt(transform);
        oldCamPos = newCamPos;
    }
}
