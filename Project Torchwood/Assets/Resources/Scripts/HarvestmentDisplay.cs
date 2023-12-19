using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarvestmentDisplay : MonoBehaviour
{
    public Text HarvestmentText;
    public string harvestmentName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int harvestmentCount = 0;
        foreach(Harvestment h in PlayerData.HarvestmentInventory){
            if(Equals(h.name,harvestmentName)){
                harvestmentCount++;
            }
        }
        HarvestmentText.text = harvestmentCount.ToString();
    }
}
