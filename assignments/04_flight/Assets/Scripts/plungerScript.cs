using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plungerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.SharedInstance.UpdateKey(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
    if (other.gameObject.CompareTag("Player")) {
        GameManager.SharedInstance.UpdateKey(1);
        Destroy(gameObject);
    }
    }
}
