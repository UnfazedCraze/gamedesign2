using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionTextDisplay : MonoBehaviour
{
    
    public Text PotionText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int atk = 0;
        int range = 0;
        if(PlayerData.PotionInventory.Count!=0){
            atk = PlayerData.PotionInventory[0].damage;
            range = 2;
        }
        PotionText.text = "Atk: "+atk+"\nRange: "+range;
    }
}
