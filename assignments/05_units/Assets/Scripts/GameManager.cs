using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public List<Vector3> foodList;
    public static event Action<Vector3> FoodSpawnedHappened;

    public bool target = false;
    private int NumOfFish = 0;
    private GameObject value;
    public static GameManager SharedInstance;

    public TMP_Text fishText;
    public Slider mySlider;

    fishScript selectedUnit;

    public GameObject pufferfishPrefab;
    public GameObject bettafishPrefab;
    public GameObject parrotfishPrefab;
    public GameObject swordfishPrefab;
    public GameObject lionfishPrefab;
    public GameObject foodPrefab;

    private bool deleteFish = false;

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
       value = ChooseMenu();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 999999))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("glass") && value != null)
                {
                    if (value == foodPrefab){
                    GameObject food = Instantiate(value, hit.point, Quaternion.identity);
                    foodList.Add(food.transform.position);
                    target = true;
                    FoodSpawnedHappened?.Invoke(foodList[0]);

                    } else if (NumOfFish < 12){
                    GameObject fish = Instantiate(value, hit.point, Quaternion.identity);
                    NumOfFish++;
                    }
        
                }

                if (deleteFish && hit.collider.gameObject.layer == LayerMask.NameToLayer("fish")){
                        Destroy(hit.collider.gameObject);
                        NumOfFish--;
                }

            }
            fishText.text = NumOfFish.ToString();
        }
    }

    GameObject ChooseMenu(){
        if (mySlider.value == 0){
            deleteFish = false;
            return pufferfishPrefab;
        } else if (mySlider.value == 1){
            deleteFish = false;
            return bettafishPrefab;
        } else if (mySlider.value == 2){
            deleteFish = false;
            return parrotfishPrefab;
        } else if (mySlider.value == 3){
            deleteFish = false;
            return swordfishPrefab;
        } else if (mySlider.value == 4){
            deleteFish = false;
            return lionfishPrefab;
        } else if (mySlider.value == 5){
            deleteFish = false;
            return foodPrefab;
        } else {
            deleteFish = true;
            return null;
        }
    }

    
}