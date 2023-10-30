using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner2 : MonoBehaviour
{
    // reference to platform Prefab
    public GameObject platformPrefab;

    // Array to store scripts of instantiated platforms
    platformScript2[] platforms;

    // Start is called before the first frame update
    void Start()
    {
        // Creates new array
        platforms = new platformScript2[9];

        // Generated 9 platforms in the bathroom
        for (int i = 0; i < 9; i++) {

            // Instantiate new platforms in a line along z axis
            Vector3 nextPlatformPOS = transform.position + transform.forward * 70 * i;
            GameObject platform = Instantiate(platformPrefab, nextPlatformPOS, transform.rotation);

            platforms[i] = platform.GetComponent<platformScript2>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
