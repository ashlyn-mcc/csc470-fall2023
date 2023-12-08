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
    private GameObject preivousClickedFish;
    public GameObject fishPanel;
    public bool target = false;
    private int NumOfFish = 0;
    private GameObject value;
    public static GameManager SharedInstance;
    private fishScript clickedFish;
    public TMP_Text fishText;
    public TMP_Text levelText;
    public TMP_Text maxText;
    public TMP_Text hungerText;
    public TMP_Text fishType;
    public Slider mySlider;
    private float originalSpeed;
    private int fishLevel;
    public GameObject pufferfishPrefab;
    public GameObject bettafishPrefab;
    public GameObject parrotfishPrefab;
    public GameObject swordfishPrefab;
    public GameObject lionfishPrefab;
    public GameObject foodPrefab;
    private float displayHunger;
    private bool deleteFish = false;
    private float currentLevel;
    public Image Container;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public float maximum = 5;

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
         maximum = 5;
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

                    } else if (NumOfFish < maximum){
                    GameObject fish = Instantiate(value, hit.point, Quaternion.identity);
                    NumOfFish++;
                    }
        
                }

                if (!deleteFish && hit.collider.gameObject.layer == LayerMask.NameToLayer("fish")){
                    fishPanel.gameObject.SetActive(true);
                    clickedFish = hit.collider.gameObject.GetComponent<fishScript>();
                    displayHunger = clickedFish.hunger;
                    fishLevel = clickedFish.level;
                    levelText.text = fishLevel.ToString();
                    hungerText.text = displayHunger.ToString();

                    if (hit.collider.tag == "puffer"){
                        Container.sprite = Sprite1;
                        fishType.text = "Pufferfish";
                    }
                    if (hit.collider.tag == "betta"){
                        Container.sprite = Sprite2;
                        fishType.text = "Betta Fish";
                    }
                    if (hit.collider.tag == "parrot"){
                        Container.sprite = Sprite3;
                        fishType.text = "Parrot Fish";
                    }
                    if (hit.collider.tag == "sword"){
                        Container.sprite = Sprite4;
                        fishType.text = "Swordfish";
                    }
                    if (hit.collider.tag == "lion"){
                        Container.sprite = Sprite5;
                        fishType.text = "Lionfish";
                    }
                } 

                if (deleteFish && hit.collider.gameObject.layer == LayerMask.NameToLayer("fish")){
                        clickedFish = hit.collider.gameObject.GetComponent<fishScript>();
                        currentLevel = clickedFish.level;
                        sellFish(currentLevel);
                        Destroy(hit.collider.gameObject);
                        NumOfFish--;
                }

            }
            fishText.text = NumOfFish.ToString();
            maxText.text = maximum.ToString();
        }

        if (GameObject.FindGameObjectsWithTag("Food").Length == 0){
            target = false;
        }

        if (target){
            FoodSpawnedHappened?.Invoke(foodList[0]);
            if (foodList[0] == null){
                foodList.RemoveAt(0);   
            }
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

    public void turnPanelOff(){
        fishPanel.gameObject.SetActive(false);
    }

    void sellFish(float level){
        if (level == 1){
            maximum += 1;
        } else if (level == 2){
             maximum += 2;
        } else if (level == 3){
             maximum += 3;
        } else if (level == 4){
             maximum += 4;
        } else if (level == 5){
             maximum += 5;
        }
    }
}