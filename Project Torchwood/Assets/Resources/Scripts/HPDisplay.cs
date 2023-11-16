using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    
    public Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.HP = 15;
    }

    // Update is called once per frame
    void Update()
    {
        HPText.text = "" + PlayerData.HP;
        
        if(Input.GetKeyDown(KeyCode.Space)){
            PlayerData.HP--;
        }
    }
}
