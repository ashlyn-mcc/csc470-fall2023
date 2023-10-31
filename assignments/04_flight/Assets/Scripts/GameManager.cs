using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager SharedInstance;
    public TMP_Text itemText;
    public TMP_Text plungerText;
    int items = 0;
    int plunger = 0;

    void Awake(){
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
