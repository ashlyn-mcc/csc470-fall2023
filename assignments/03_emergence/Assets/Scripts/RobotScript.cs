using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobotScript : MonoBehaviour
{
    public bool alive = false;
    private bool dontRepeat = true;
    public bool spawn = false;


    public GameObject dronePrefab;

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
        }

        if ((spawn) && (dontRepeat)){
            Vector3 posVal = transform.position;
            posVal.z = posVal.z + 10;
            Quaternion rotVal = Quaternion.Euler(0, 360, 0);
            GameObject droneObj = Instantiate(dronePrefab, posVal, rotVal);
            spawn = false;
            dontRepeat = false;
        }
    }

    bool RandomBool()
    {
        return (Random.value > 0.9f);
    }

}