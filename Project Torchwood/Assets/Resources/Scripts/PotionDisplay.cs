using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionDisplay : MonoBehaviour
{
    public Text PotionText;
    public string potionName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int potionCount = 0;
        foreach(Potion m in PlayerData.PotionInventory){
            if(Equals(m.name,potionName)){
                potionCount++;
            }
        }
        PotionText.text = potionCount.ToString();
    }
}
