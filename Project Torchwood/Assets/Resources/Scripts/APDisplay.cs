using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APDisplay : MonoBehaviour
{
    
    public Text APText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        APText.text = "| AP:" + PlayerData.AP;
        

    }
}
