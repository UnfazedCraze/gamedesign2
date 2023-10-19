using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftingTableOpenScript : MonoBehaviour
{
    public Canvas canvas;
    private bool isOpen = false;

    // public GameObject craftingTable;
    // public TMP_Text craftingTableText;
    public void openCraftingTable(){
        Debug.Log("Open the crafting table");
        if(!isOpen){
            isOpen = true;
            canvas.enabled = true;
        }else{
            isOpen = false;
            canvas.enabled = false;
        }

    }

}
