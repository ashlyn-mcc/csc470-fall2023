using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DroneFlyingScrpit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Drones fly towards the player (camera)
        Vector3 posCam = new Vector3(39,31,99);
        var movement = 6f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,posCam,movement);
    }

// When drone collides with laser the drone is destroyed
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
    }
}
