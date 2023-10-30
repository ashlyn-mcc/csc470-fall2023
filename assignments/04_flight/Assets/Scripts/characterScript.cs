using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{

    private CharacterController cc;
    public GameObject cameraObject;
    Vector3 myVector;
    Vector3 oldCamPos;
    Vector3 amountToMove;
    float rotateSpeed = 60;
    float forwardSpeed = 75;
    float jumpForce = 230;
    float gravityModifier =20.0f;
    private bool changeCam = false;


    // gravity accumulator
    float yVelocity = 0;

    void Start()
    {
        // Get the character controller
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {

        // Get axis
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");


        
        if (!cc.isGrounded)
        {
            yVelocity += Physics.gravity.y * gravityModifier * Time.deltaTime;
        } else {
            yVelocity = -1;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpForce;
            }
        }

        cameraObject.transform.LookAt(transform);

        if (transform.position.x > 470){
            changeCam = true;
        }

        if(changeCam){

            myVector = transform.position - transform.forward * 50 ;

            // Player can now rotate
            transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);

            // Camera's new position is behind and above the player
            Vector3 newCamPos = transform.position + -transform.forward * 100 + Vector3.up * 50;

            // Handles null
            if (oldCamPos == null){
                oldCamPos = newCamPos;
             }

            // Places camera at the average of the new and old calculated position
            cameraObject.transform.position = (newCamPos + oldCamPos) / 2f; 

            // Sets new position as old position
            oldCamPos = newCamPos;

            // moves character based on vertical axis
            amountToMove = vAxis * transform.forward * forwardSpeed;
        }

        else{
            // Set vector that camera will be away from character
            myVector = new Vector3(1.0f, 1.0f, 500.0f);

            // Move camera's x along with character's
            cameraObject.transform.position = transform.position - myVector;

            // Move character based on horizontal axis
            amountToMove = hAxis * transform.forward * forwardSpeed;
        }

            // account for gravity
            amountToMove.y = yVelocity;

            // Move character calculated amount
            cc.Move(amountToMove * Time.deltaTime);

    }
}
