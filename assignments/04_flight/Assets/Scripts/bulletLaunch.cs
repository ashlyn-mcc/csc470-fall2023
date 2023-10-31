using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLaunch : MonoBehaviour
{
    public GameObject bulletObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject bullet = Instantiate(bulletObj, transform.position, transform.rotation);


            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 10000);
        }
    }

}
