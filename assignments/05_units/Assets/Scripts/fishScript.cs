using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishScript : MonoBehaviour{
private bool findingFood = false;
Vector3 target; 
private MeshRenderer exclamationRenderer;
private MeshRenderer pointRenderer;
private AudioSource splashAudio;

bool direction = false;
Vector3 swimming = new Vector3(1f,0f,0f);
Vector3 currentEulerAngles;

float[] Speeds = {1f, 1.25f, 1.5f, 2.0f, 2.5f};
float[] Speeds2 = {2.5f, 2.75f, 3f, 3.25f, 3.5f, 3.75f, 4f, 4.25f, 4.5f};
public float speed = 0;
float speed2 = 0;
public float hunger = 100.0f; 

private bool created = true;

private float spawnTime;
private float timeAlive;
public int level;

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();      
        int index = random.Next(0, Speeds.Length);
        speed = Speeds[index];

        System.Random random2 = new System.Random();      
        int index2 = random2.Next(0, Speeds2.Length);
        speed2 = Speeds2[index2];

        transform.position -= swimming * speed * Time.deltaTime;

        splashAudio = GetComponent<AudioSource>();

        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive = Time.time - spawnTime;
        Debug.Log("Time elapsed" + timeAlive);
        Level();
        
        if (created){
        splashAudio.Play();
        created = false;
        }

        hunger = hunger - 0.01f;

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
        
        if (target.x < transform.position.x){
            currentEulerAngles = new Vector3(0f, -90f, 0f);
        } else {
            currentEulerAngles = new Vector3(0f, -270f, 0f);
        }

        transform.eulerAngles = currentEulerAngles;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target, speed * speed2 * Time.deltaTime);
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

    void Level(){
        if (timeAlive > 300){
            level = 5;
        } else if (timeAlive > 240){
            level = 4;
        } else if (timeAlive > 180){
            level = 3;
        } else if (timeAlive > 120){
            level = 2;
        } else if (timeAlive > 60){
            level = 1;
        } else {
            level = 0;
        }
    }
}