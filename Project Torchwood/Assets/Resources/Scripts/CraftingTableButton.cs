using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTableButton : MonoBehaviour
{
    public CraftingSlot[] craftingSlots;
    public string itemName;
    public Sprite itemImage;

    public CraftingTableManager manager;


    
    //Check whether there is an available recipe

    public void CraftingTableButtonOnClick(){

        foreach(CraftingSlot slot in craftingSlots){
            Item item = new Harvestment(itemName);

            if(slot.item == null){
                bool hasItem = false;
                int index = 0;
                foreach(Harvestment harvestment in PlayerData.HarvestmentInventory){
                    Debug.Log(harvestment.name+","+item.name);
                    Debug.Log(harvestment.name == item.name);
                    if(harvestment.name == item.name){
                        hasItem = true;
                        Debug.Log(item.name+"Equal"+harvestment.name);
                        item = harvestment;
                        PlayerData.HarvestmentInventory.RemoveAt(index);
                        break;
                    }
                    index ++;
                }
                if(!hasItem){
                    Debug.Log("You do not have this item.");
                    return;
                }
                slot.gameObject.SetActive(true);
                slot.GetComponent<Image>().sprite = itemImage;
                slot.item = item;
                Debug.Log("ItemList:"+manager.itemList == null);
                manager.itemList[slot.index] = item;
                
                manager.checkCraftingTable();
                return;
                
            } 
        }
    }
}
