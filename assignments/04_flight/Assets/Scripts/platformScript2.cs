using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript2 : MonoBehaviour
{

    float direction = 0.0f;
    float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Direction and speed of platformsrandomly generated at start
        if (RandomBool()){
            direction = 1.0f;
        }
        else{
            direction = -1.0f;
        }
         if (RandomBool()){
            speed = 0.75f;
        }
        else{
            speed = 0.50f;
        }
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

    bool RandomBool()
    {
        // returns true 50% of the time
        return (Random.value > 0.5f);
    }
}
