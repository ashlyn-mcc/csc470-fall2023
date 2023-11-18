using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager SharedInstance;

    public Slider mySlider;

    fishScript selectedUnit;

    public GameObject pufferfishPrefab;
    public GameObject bettafishPrefab;
    public GameObject parrotfishPrefab;
    public GameObject swordfishPrefab;
    public GameObject lionfishPrefab;

    void Awake()
    {
        if (SharedInstance != null)
        {
            Debug.Log("Why is there more than one GameManager!?!?!?!");
        }
        SharedInstance = this;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 999999))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("glass"))
                {
                    GameObject fish = Instantiate(ChooseFish(), hit.point, Quaternion.identity);
            
                }
            }
        }
    }

    GameObject ChooseFish(){
        if (mySlider.value == 0){
            return pufferfishPrefab;
        } else if (mySlider.value == 1){
            return bettafishPrefab;
        } else if (mySlider.value == 2){
            return parrotfishPrefab;
        } else if (mySlider.value == 3){
            return swordfishPrefab;
        } else {
            return lionfishPrefab;
        }
    }

    
}