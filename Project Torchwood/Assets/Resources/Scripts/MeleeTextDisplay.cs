using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeTextDisplay : MonoBehaviour
{
    
    public Text MeleeText;
    public GameObject MeleeSlot;
    public Sprite BasicSword;
    public Sprite DualKatana;
    public Sprite Scythe;
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
            if(Equals(PlayerData.MeleeInventory.Peek().name,"1")){
                MeleeSlot.GetComponent<Image>().sprite = BasicSword;
            }else if(Equals(PlayerData.MeleeInventory.Peek().name,"2")){
                MeleeSlot.GetComponent<Image>().sprite = DualKatana;
            }else if(Equals(PlayerData.MeleeInventory.Peek().name,"3")){
                MeleeSlot.GetComponent<Image>().sprite = Scythe;
            }
            
        }
        MeleeText.text = "Atk: "+atk+"\nDura: "+durability;
    }
}
