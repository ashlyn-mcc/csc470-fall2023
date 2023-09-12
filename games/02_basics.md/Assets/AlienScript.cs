using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public GameObject AlienPrefab;
    public GameObject Planet;

    // Start is called before the first frame update
    void Start()
    {
        generateAlien();
    
    }
    
    void generateAlien()
    {
         for (int i = 0; i < 50; i++)
            {
            
            float circle = 2 * Mathf.PI / 50 * i;
            float x = Mathf.Cos(circle);
            float y = 0;
            float z = Mathf.Sin(circle);
            Vector3 circlePosition = new Vector3(x, y, z);
            
            var gamePosition = circlePosition * 60;
            GameObject AlienPre = Instantiate(AlienPrefab, gamePosition, Quaternion.identity);
            
             }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            {
            Vector3 pos = new Vector3(27,78,2);
            GameObject falling = Instantiate(Planet, pos, Quaternion.identity);
            }
    }
    
}


