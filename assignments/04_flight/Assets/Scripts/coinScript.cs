using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
    GameManager.SharedInstance.UpdateItems(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void OnTriggerEnter(Collider other)
    {
    if (other.gameObject.CompareTag("Player")) {
        GameManager.SharedInstance.UpdateItems(1);
        Destroy(gameObject);
    }
    }
}
