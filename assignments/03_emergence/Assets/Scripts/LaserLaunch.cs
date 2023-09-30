using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLaunch : MonoBehaviour
{
    public GameObject laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = transform.position;
            pos.z = pos.z - 0.5f;
            Quaternion newRotation = Quaternion.Euler(90, 0, 0);
            GameObject laser = Instantiate(laserPrefab, pos, newRotation);


            Rigidbody rb = laser.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 5000);
        }
    }

}
