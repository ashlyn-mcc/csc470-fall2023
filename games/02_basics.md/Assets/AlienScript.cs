using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public GameObject AlienPrefab;
    public GameObject Planet;
    public GameObject Stars;

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
        
        for (int i = 0; i < 10; i++)
            {
                float x2 = 65 - (i*11);
                float y2 = 103 - (i*10);
                float z2 = 4;
                Vector3 lineposition = new Vector3(x2, y2, z2);
            
                GameObject AlienPre2 = Instantiate(AlienPrefab, lineposition, Quaternion.identity);
                }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            {
	    Vector3 pposition = new Vector3(85, 103, 3);
            GameObject Planet1 = Instantiate(Planet, pposition, Quaternion.identity);
	    Planet.transform.position = Planet.transform.forward * 4f * Time.deltaTime;
            }
	    
        float x = Random.Range(-150, 150);
        float y = 200;
        float z = Random.Range(-150, 150);
        Vector3 pos = new Vector3(x, y, z);
        GameObject rain = Instantiate(Stars, pos, Quaternion.identity);
        Destroy(rain, 7);
    }
    
}


