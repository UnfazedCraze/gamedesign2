using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantDisplay : MonoBehaviour
{
    public Text PlantText;
    public string plantName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int plantCount = 0;
        foreach(Plant p in PlayerData.PlantInventory){
            if(Equals(p.name,plantName)){
                plantCount++;
            }
        }
        PlantText.text = plantCount.ToString();
    }
}
