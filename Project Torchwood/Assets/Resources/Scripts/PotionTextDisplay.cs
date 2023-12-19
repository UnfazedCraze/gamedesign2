using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionTextDisplay : MonoBehaviour
{
    
    public Text PotionText;
    public GameObject PotionSlot;
    public Sprite BasicPotion;
    public Sprite HealingPotion;
    public Sprite FreezingPotion;
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
            atk = PlayerData.PotionInventory.Peek().damage;
            range = 2;
            if(Equals(PlayerData.PotionInventory.Peek().name,"1")){
                PotionSlot.GetComponent<Image>().sprite = BasicPotion;
            }else if(Equals(PlayerData.PotionInventory.Peek().name,"2")){
                PotionSlot.GetComponent<Image>().sprite = HealingPotion;
            }else if(Equals(PlayerData.PotionInventory.Peek().name,"3")){
                PotionSlot.GetComponent<Image>().sprite = FreezingPotion;
            }
        }
        PotionText.text = "Atk: "+atk+"\nRange: "+range;
    }
}
