using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager SharedInstance;

    public TMP_Text itemText;
    public TMP_Text plungerText;
    public TMP_Text catText;

    int items = 0;
    int plunger = 0;
    int collections = 0;
    int terminated = 0;

    public Material beige;
    public Material ocean;

    public bool ship = false;
    public bool complete = false;

    void Awake(){
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = beige;
    }

    // Update is called once per frame
    void Update()
    {
        collections = items + plunger + terminated;
        if (collections == 14){
            complete = true;
        }
    }

    public void UpdateItems(int amount)
    {
        items += amount;
        itemText.text = items.ToString();
    }

    public void UpdateKey(int collected)
    {
        plunger += collected;
        plungerText.text = plunger.ToString();

    }
    public void UpdateCats(int cats)
    {
        terminated += cats;
        catText.text = terminated.ToString();
    }

    public void changeSkybox(bool change)
    {
        if (change){
        RenderSettings.skybox = ocean;
        ship = true;
        }
    }

}
