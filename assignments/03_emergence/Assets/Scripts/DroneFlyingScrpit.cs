using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DroneFlyingScrpit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posCam = new Vector3(38,31,98);
        var movement = 5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,posCam,movement);
    }
}
