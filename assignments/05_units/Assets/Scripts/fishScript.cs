using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fishScript : MonoBehaviour{

bool direction = false;
Vector3 swimming = new Vector3(1f,0f,0f);
Vector3 currentEulerAngles;

float[] Speeds = {0.5f, 0.75f, 1f, 1.25f, 1.5f, 2.0f, 2.5f};
float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();       
        int index = random.Next(0, Speeds.Length);
        speed = Speeds[index];
        transform.position -= swimming * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Swim();

        if (direction){
            currentEulerAngles = new Vector3(0f, -270f, 0f);
            transform.position += swimming * speed * Time.deltaTime;
        } else {
            currentEulerAngles = new Vector3(0f, -90f, 0f);
            transform.position -= swimming * speed * Time.deltaTime;
        }

        transform.eulerAngles = currentEulerAngles;

    }

    private void Swim(){

        if (transform.position.x > 14.75){
            direction = false;
        }
        if (transform.position.x < -14.75){
            direction = true;
        }

    }



}