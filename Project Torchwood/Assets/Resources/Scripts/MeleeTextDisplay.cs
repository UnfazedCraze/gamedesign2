using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeTextDisplay : MonoBehaviour
{
    
    public Text MeleeText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int atk = 0;
        int durability = 0;
        if(PlayerData.MeleeInventory.Count!=0){
            atk = PlayerData.MeleeInventory.Peek().damage;
            durability = PlayerData.MeleeInventory.Peek().durability;
        }
        MeleeText.text = "Atk: "+atk+"\nDurability: "+durability;
    }
}
