using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishScript : MonoBehaviour{
    
    // Vectors for food target posiiton, swimming step increase, angle of fish rotation
    Vector3 target; 
    Vector3 swimming = new Vector3(1f,0f,0f);
    Vector3 currentEulerAngles;

    // Mesh renderers of warning exclamation point
    private MeshRenderer exclamationRenderer;
    private MeshRenderer pointRenderer;

    // Audio source for splash noise
    private AudioSource splashAudio;


    bool direction = false;
    private bool created = true;

    // Arrays of speeds 
    float[] Speeds = {1f, 1.25f, 1.5f, 2.0f, 2.5f};
    float[] Speeds2 = {2.5f, 2.75f, 3f, 3.25f, 3.5f, 3.75f, 4f, 4.25f, 4.5f};
    float[] Directions = {0f, 1f};

    public float speed = 0;
    float speed2 = 0;
    float newDirection = 0;
    public float hunger = 100.0f; 
    float spawnTime;
    float timeAlive;

    public int level;

    // Start is called before the first frame update
    void Start()
    {
        // Selects random speed for the fish
        System.Random random = new System.Random();      
        int index = random.Next(0, Speeds.Length);
        speed = Speeds[index];

        // Selects random secondary speed for when the fish moves towards food
        System.Random random2 = new System.Random();      
        int index2 = random2.Next(0, Speeds2.Length);
        speed2 = Speeds2[index2];

        // Selects random value of 0 or 1. Determines direction of fish when spwaned in tank
        System.Random chooseDirection = new System.Random();      
        int index3 = chooseDirection.Next(0, Directions.Length);
        newDirection = Directions[index3];

        // Based on random value fish moves in either direction
        if (newDirection == 0){
            transform.position -= swimming * speed * Time.deltaTime;
            direction = false;
        } 
        if (newDirection == 1){
            transform.position += swimming * speed * Time.deltaTime;
            direction = true;
        }

        // Splash noise 
        splashAudio = GetComponent<AudioSource>();

        // Get the time when the fish is spawned
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // How long the fish has been instantiated
        timeAlive = Time.time - spawnTime;

        // Updates fish's level based on time alive
        Level();
        
        // Plays splash noise once when fish is spawned
        if (created){
        splashAudio.Play();
        created = false;
        }

        // Hunger is constantly decreasing 
        hunger = hunger - 0.01f;

        // If fish reaches edge of tank, switch direction 
        Swim();

        // Enter if there is no target fot the fish (food is not in tank)
        if (GameManager.SharedInstance.target == false){

            // Continue moving in whichever direction the fish was instantiated with
            // Rotate accordingly
            if (direction){
                currentEulerAngles = new Vector3(0f, -270f, 0f);
                transform.position += swimming * speed * Time.deltaTime;
            } else {
                currentEulerAngles = new Vector3(0f, -90f, 0f);
                transform.position -= swimming * speed * Time.deltaTime;
            }

            transform.eulerAngles = currentEulerAngles;

        } else{
        
        // If a target is set rotate towards target
        if (target.x < transform.position.x){
            currentEulerAngles = new Vector3(0f, -90f, 0f);
        } else {
            currentEulerAngles = new Vector3(0f, -270f, 0f);
        }

        transform.eulerAngles = currentEulerAngles;

        // Move towards food when spawned
        Vector3 newPosition = Vector3.MoveTowards(transform.position, target, speed * speed2 * Time.deltaTime);
        transform.position = newPosition;
        }

        // Exclamation point that appears when hunger is low
        Transform exclamation = transform.Find("Exclamation");
        exclamationRenderer = exclamation.GetComponent<MeshRenderer>();
        Transform point = transform.Find("Point");
        pointRenderer = point.GetComponent<MeshRenderer>();
        
        // Enable/ Disable exclamation point based on hunger level
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

    // Switch direction of fish when it hits edge of tank
    private void Swim(){

        if (transform.position.x > 14.75){
            direction = false;
        }
        if (transform.position.x < -14.75){
            direction = true;
        }

    }

    // Food action event
    private void OnEnable()
    {
        GameManager.FoodSpawnedHappened += moveToFood;
    }

     private void OnDisable()
    {
        GameManager.FoodSpawnedHappened -= moveToFood;
    }


    // Set the fish's target to the position of the food
    private void moveToFood(Vector3 food)
    {
        target = food;
    }

    // If fish collides with food, increase hunger by 20
     void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            hunger += 20.0f;
        }
    }

    // Based on time alive change the level of the fish
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