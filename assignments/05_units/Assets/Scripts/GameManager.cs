using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;

    public List<Vector3> foodList;

    public static event Action<Vector3> FoodSpawnedHappened;

    private GameObject preivousClickedFish;
    private GameObject value;
    public GameObject fishPanel;
    public GameObject pufferfishPrefab;
    public GameObject bettafishPrefab;
    public GameObject parrotfishPrefab;
    public GameObject swordfishPrefab;
    public GameObject lionfishPrefab;
    public GameObject foodPrefab;

    public bool target = false;
    private bool deleteFish = false;

    // Amount of 
    private int NumOfFish = 0;
    private int fishLevel;

    // References the script of the fish that has been clicked
    private fishScript clickedFish;
    
    // UI Text
    public TMP_Text fishText;
    public TMP_Text levelText;
    public TMP_Text maxText;
    public TMP_Text hungerText;
    public TMP_Text fishType;

    // Slider that controls fish, food, and selling
    public Slider mySlider;
    
    // Values displayed on the UI
    private float displayHunger;
    private float currentLevel;
    public float maximum = 5;

    // Container that cold sprites displayed on panel when a fish is clicked
    public Image Container;

    // Fish sprites displayed on panel when a fish is clicked
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
   

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
        // Maximum number of fish in the tank starts at 5
         maximum = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // Returns value of the slider
        value = ChooseMenu();

        // Enter when mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Creates raycast from camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 999999))
            {
                // Enters here when inside the fish tank is clicked 
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("glass") && value != null)
                {
                    // Enter if the slider was on "spawn food"
                    if (value == foodPrefab){
                    // Create food prefab
                    GameObject food = Instantiate(value, hit.point, Quaternion.identity);
                    // Add it to list
                    foodList.Add(food.transform.position);
                    // Indicate there is a target set for the fish
                    target = true;

                    // Otherwise the spawner was on a fish, enter here
                    } else if (NumOfFish < maximum){
                    // Create fish prefab
                    GameObject fish = Instantiate(value, hit.point, Quaternion.identity);
                    // Increase the count of number of fish in tank
                    NumOfFish++;
                    }
        
                }

                // Enter if a fish is clicked and slider isn't set to delete fish
                if (!deleteFish && hit.collider.gameObject.layer == LayerMask.NameToLayer("fish")){

                    // Activate panel with fish metrics
                    fishPanel.gameObject.SetActive(true);

                    // Get the script of the clicked fish
                    clickedFish = hit.collider.gameObject.GetComponent<fishScript>();

                    // Get values from the fish's script and display on panel text
                    displayHunger = MathF.Round(clickedFish.hunger);
                    fishLevel = clickedFish.level;
                    levelText.text = fishLevel.ToString();
                    hungerText.text = displayHunger.ToString();

                    // Display image and title of the fish on panel
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

                // Enter if slider is set to delete fish and object clicked is a fish
                if (deleteFish && hit.collider.gameObject.layer == LayerMask.NameToLayer("fish"))
                {
                        // Get script of clicked fish
                        clickedFish = hit.collider.gameObject.GetComponent<fishScript>();
                        currentLevel = clickedFish.level;
                
                        // Change tank maximum to new value based on fish level
                        sellFish(currentLevel);

                        // Destroy fish that was sold and decrease the number of fish
                        Destroy(hit.collider.gameObject);
                        NumOfFish--;
                }

            }

            // Change text of number of fish in tank/ number allowed
            fishText.text = NumOfFish.ToString();
            maxText.text = maximum.ToString();
        }

        // If there are no food objects in the tank, indicate there is no target for the fish
        if (GameObject.FindGameObjectsWithTag("Food").Length == 0){
            target = false;
        }

        // If there is a target for the fish, send broadcast to move towards the food
        if (target){
            FoodSpawnedHappened?.Invoke(foodList[0]);
            // If the first element has been eaten (and destroyed), remove it from the list
            if (foodList[0] == null){
                foodList.RemoveAt(0);   
            }
        }

       

    }

    // Based on slider value, return the corresponding prefab
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

    // On button click (the x button on the screen), the panel with fish metrics is turned off
    public void turnPanelOff(){
        fishPanel.gameObject.SetActive(false);
    }

    // Depending on fish's level update the tank maximum capacity when that fish is sold
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