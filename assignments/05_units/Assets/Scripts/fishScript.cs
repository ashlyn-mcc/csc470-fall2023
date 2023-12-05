using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fishScript : MonoBehaviour{
private bool findingFood = false;
Vector3 target; 
private MeshRenderer exclamationRenderer;
private MeshRenderer pointRenderer;

bool direction = false;
Vector3 swimming = new Vector3(1f,0f,0f);
Vector3 currentEulerAngles;

float[] Speeds = {1f, 1.25f, 1.5f, 2.0f, 2.5f};
float speed = 1;
float hunger = 100.0f; 

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
        hunger = hunger - 0.03f;

        Swim();
        if (GameManager.SharedInstance.target == false){

        if (direction){
            currentEulerAngles = new Vector3(0f, -270f, 0f);
            transform.position += swimming * speed * Time.deltaTime;
        } else {
            currentEulerAngles = new Vector3(0f, -90f, 0f);
            transform.position -= swimming * speed * Time.deltaTime;
        }

        transform.eulerAngles = currentEulerAngles;
        } else{
        
        if (target.x < 0f){
            currentEulerAngles = new Vector3(0f, -90f, 0f);
        } else {
            currentEulerAngles = new Vector3(0f, -270f, 0f);
        }
        transform.eulerAngles = currentEulerAngles;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target, speed * 2.0f * Time.deltaTime);
        transform.position = newPosition;
        }

        Transform exclamation = transform.Find("Exclamation");
        exclamationRenderer = exclamation.GetComponent<MeshRenderer>();
        Transform point = transform.Find("Point");
        pointRenderer = point.GetComponent<MeshRenderer>();
        
        if (hunger <= 0){
            Destroy(gameObject);
        } else if (hunger <= 50){
            exclamationRenderer.enabled = true;
            pointRenderer.enabled = true;
        } else {
            exclamationRenderer.enabled = false;
            pointRenderer.enabled = false;
        }
    }

    private void Swim(){

        if (transform.position.x > 14.75){
            direction = false;
        }
        if (transform.position.x < -14.75){
            direction = true;
        }

    }


    private void OnEnable()
    {
        GameManager.FoodSpawnedHappened += moveToFood;
    }

     private void OnDisable()
    {
        GameManager.FoodSpawnedHappened -= moveToFood;
    }


    private void moveToFood(Vector3 food)
    {
        target = food;
    }

     void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            hunger += 20.0f;
        }
    }
}