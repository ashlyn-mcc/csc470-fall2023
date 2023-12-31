using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobotScript : MonoBehaviour
{
    public bool alive = false;
    public bool spawn = false;


    public GameObject dronePrefab;

    // Start is called before the first frame update
    void Start()
    {
        // picks random alive value (either alive or dead to start)
        alive = RandomBool();

        // Makes robot black
        if (alive == false){
            Renderer rend = gameObject.GetComponentInChildren<Renderer>();
            rend.material.SetColor("_Color", Color.black);
        }
        // Makes robot red
        else {
            Renderer rend = gameObject.GetComponentInChildren<Renderer>();
            rend.material.SetColor("_Color", Color.red);
    

        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (alive == false){
            Renderer rend = gameObject.GetComponentInChildren<Renderer>();
            rend.material.SetColor("_Color", Color.black);
        }
        else {
            Renderer rend = gameObject.GetComponentInChildren<Renderer>();
            rend.material.SetColor("_Color", Color.red);
        }

        // doesn't allow robots that already produced a drone produce another
        if (spawn){
            Vector3 posVal = transform.position;
            posVal.z = posVal.z + 10;
            Quaternion rotVal = Quaternion.Euler(0, 360, 0);
            GameObject droneObj = Instantiate(dronePrefab, posVal, rotVal);
            spawn = false;
        }
    }

    bool RandomBool()
    {
        // returns true 15% of the time
        return (Random.value > 0.85f);
    }

}