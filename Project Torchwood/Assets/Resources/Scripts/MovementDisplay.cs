using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementDisplay : MonoBehaviour
{
    
    public Text MovementText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.AP = PlayerData.maxAP;
    }

    // Update is called once per frame
    void Update()
    {
        // MovementText.text = "Mov: " + PlayerData.mov;

    }
}
