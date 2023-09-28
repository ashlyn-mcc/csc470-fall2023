using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobotScript : MonoBehaviour
{
    public bool alive = false;
    // public GameObject dronePrefab;

    // Start is called before the first frame update
    void Start()
    {
        alive = RandomBool();

        if (alive == false){
            Renderer rend = gameObject.GetComponentInChildren<Renderer>();
            rend.material.SetColor("_Color", Color.black);
        }
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

            // Vector3 posVal = transform.position;
            // posVal.z = posVal.z + 5;
            // GameObject droneObj = Instantiate(dronePrefab, posVal, transform.rotation);

        }
    }

    bool RandomBool()
    {
        return (Random.value > 0.9f);
    }

}