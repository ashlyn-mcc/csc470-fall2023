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
         for (int i = 0; i < 10; i++)
            {
            
            float circle = 2 * Mathf.PI / 10 * i;
            float x = Mathf.Cos(circle);
            float y = 0;
            float z = Mathf.Sin(circle);
            Vector3 circlePosition = new Vector3(x, y, z);
           
            var center = new Vector3(-5, -22, 41);
            var gamePosition = circlePosition + center * 10;
            GameObject AlienPre = Instantiate(AlienPrefab, gamePosition, Quaternion.identity);
            
             }
        
        for (int i = 0; i < 10; i++)
            {
                float x2 = -2 + i;
                float y2 = 7;
                float z2 = -4;
                Vector3 lineposition = new Vector3(x2, y2, z2);
            
                GameObject AlienPre2 = Instantiate(AlienPrefab, lineposition, Quaternion.identity);
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


