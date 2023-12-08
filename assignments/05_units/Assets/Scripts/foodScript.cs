using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodScript : MonoBehaviour
{

    Vector3 speed;

    private bool hasTarget = false;

    void Start()
    {
        speed = new Vector3(0.0f,0.0f,0.0f);
    }

    void Update()
    {

        transform.position = transform.position - speed * Time.deltaTime;

    }

   void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("sword") || collision.gameObject.CompareTag("puffer") || collision.gameObject.CompareTag("parrot") || collision.gameObject.CompareTag("lion") || collision.gameObject.CompareTag("betta"))
        {
            GameManager.SharedInstance.foodList.RemoveAt(0);
            //GameManager.SharedInstance.target = false;
            Destroy(gameObject);
        }
    }

}
