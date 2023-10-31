using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("finish")) {
            Debug.Log("Connection");
            SceneManager.LoadScene(1);
         }
    }
}
