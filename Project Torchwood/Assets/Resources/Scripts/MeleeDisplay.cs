using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeDisplay : MonoBehaviour
{
    public Text MeleeText;
    public string meleeName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int meleeCount = 0;
        foreach(Melee m in PlayerData.MeleeInventory){
            if(Equals(m.name,meleeName)){
                meleeCount++;
            }
        }
        MeleeText.text = meleeCount.ToString();
    }
}
