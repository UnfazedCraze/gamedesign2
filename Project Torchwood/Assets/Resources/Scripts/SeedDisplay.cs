using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedDisplay : MonoBehaviour
{
    public Text SeedText;
    public string seedName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int seedCount = 0;
        foreach(Seed s in PlayerData.SeedInventory){
            if(Equals(s.name,seedName)){
                seedCount++;
            }
        }
        SeedText.text = seedCount.ToString();
    }
}
