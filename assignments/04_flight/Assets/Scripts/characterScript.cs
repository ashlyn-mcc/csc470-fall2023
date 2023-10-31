using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{

    private CharacterController cc;
    public GameObject cameraObject;
    public GameObject playerPrefab;
    public GameObject shipPrefab;

    Vector3 myVector;
    Vector3 oldCamPos;
    Vector3 amountToMove;
    Vector3 respawnPoint;
    Vector3 shipSpawn;
    Quaternion initialRotation;

    float rotateSpeed = 60;
    float forwardSpeed = 75;
    float jumpForce = 230;
    float gravityModifier =20.0f;
    float backMultiplier = 100;
    float upwardMultiplier = 80;
    float hAxis = 0.0f;
    float vAxis = 0.0f;

    public bool floorCollide = false;
    private bool changeCam = false;



    // gravity accumulator
    float yVelocity = 0;

    void Start()
    {
        // Get the character controller
        cc = GetComponent<CharacterController>();

        initialRotation = transform.rotation;
    }

    void Update()
    {

        // Get axis
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");


        
        if (!cc.isGrounded)
        {
            yVelocity += Physics.gravity.y * gravityModifier * Time.deltaTime;
        } 
        else 
        {
            yVelocity = -1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
        }

        // Camera looks at the game object 
        cameraObject.transform.LookAt(transform);

        // Occurs once you reach end of first level 
        if (transform.position.x > 470){
            changeCam = true;
        }

        if (changeCam){
            level2();
        }
        else{
           hAxisMovement();
        }

        if (transform.position.y < 338){
            backMultiplier = 150;
            upwardMultiplier = 75;
            gravityModifier = 15.0f;
            rotateSpeed = 120;
            jumpForce = 100;
            forwardSpeed = 75;
        }

            // account for gravity
            amountToMove.y = yVelocity;

            // Move character calculated amount
            cc.Move(amountToMove * Time.deltaTime);

        
            

    }


    void level2(){
            myVector = transform.position - transform.forward * 50 ;

            // Player can now rotate
            transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);

            // Camera's new position is behind and above the player
            Vector3 newCamPos = transform.position + -transform.forward * backMultiplier + Vector3.up * upwardMultiplier;

            // Handles null
            if (oldCamPos == null){
                oldCamPos = newCamPos;
             }

            // Places camera at the average of the new and old calculated position
            cameraObject.transform.position = (newCamPos + oldCamPos) / 2f; 

            // Sets new position as old position
            oldCamPos = newCamPos;
            jumpForce = 100;
            gravityModifier = 7.0f;
            forwardSpeed = 100;

            amountToMove.z = hAxis * forwardSpeed;

            // moves character based on vertical axis
            amountToMove = vAxis * transform.forward * forwardSpeed;
    }

    void hAxisMovement(){
            // Set vector that camera will be away from character
            myVector = new Vector3(1.0f, 1.0f, 500.0f);

            // Move camera's x along with character's
            cameraObject.transform.position = transform.position - myVector;

            // Move character based on horizontal axis
            amountToMove = hAxis * transform.forward * forwardSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
    if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("cat")) {

        respawnPoint = new Vector3(-829.70f,807.39f,-685.0f);

        GameObject player = Instantiate(playerPrefab, respawnPoint, initialRotation);

        Destroy(gameObject);

    }

    if (other.gameObject.CompareTag("toilet")) {
        
        if(GameManager.SharedInstance.complete)
        {
        GameManager.SharedInstance.changeSkybox(true);
        Destroy(gameObject);
        Debug.Log("this is happening");
        }
    }

    }



}
