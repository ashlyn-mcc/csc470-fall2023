using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RobotScript : MonoBehaviour
{
    public bool alive = false;

    // Start is called before the first frame update
    void Start()
    {
        alive = RandomBool();

        if (alive == false){
            Renderer rend = gameObject.GetComponentInChildren<Renderer>();
            rend.material.SetColor("_Color", Color.gray);
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
            rend.material.SetColor("_Color", Color.gray);
        }
        else {
            Renderer rend = gameObject.GetComponentInChildren<Renderer>();
            rend.material.SetColor("_Color", Color.red);

        }
    }

    bool RandomBool()
    {
        return (Random.value > 0.5f);
    }

}