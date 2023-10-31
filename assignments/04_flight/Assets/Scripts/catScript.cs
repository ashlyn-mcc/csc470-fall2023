using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    GameManager.SharedInstance.UpdateCats(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
    if (other.gameObject.CompareTag("Bullet")) {
        GameManager.SharedInstance.UpdateCats(1);
        Destroy(gameObject);
    }
    }
}
