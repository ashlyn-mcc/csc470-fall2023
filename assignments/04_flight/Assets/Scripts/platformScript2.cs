using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript2 : MonoBehaviour
{

    float direction = 1.0f;
    float speed = 0.1f;

    public GameObject character; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
     // Changes direction of platforms so they bounce back and forth
        if (transform.position.z > 250.0f){
            direction = -1.0f;
        }
        if (transform.position.z < -200.0f){
            direction = 1.0f;
        }

        transform.position = transform.position + new Vector3(0.0f,0.0f,speed) * direction;

    }



}
