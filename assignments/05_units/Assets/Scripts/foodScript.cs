using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderScript : MonoBehaviour
{

    Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector3(0.0f,0.5f,0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - speed * Time.deltaTime;
    }
}
