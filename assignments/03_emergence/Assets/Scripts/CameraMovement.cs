using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private float x;
    private float y;
    public float sensitivity = -1.0f;
    public float sensitivity2 = 1.0f;
    private Vector3 rotate;
  
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotation();
    }

    // Camera moves with mouse rotation (first person)
    void MouseRotation(){
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotate = new Vector3(x * sensitivity2, y * sensitivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
    }
}
