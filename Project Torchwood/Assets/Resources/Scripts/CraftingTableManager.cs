using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingTableManager : MonoBehaviour
{    

    public CraftingSlot resultSlot;

    public Item[] itemList = new Item[2];
    public string[] recipes;
    public Item[] recipeResults = {new Melee("1",5,2),new Melee("2",8,3),new Melee("3",12,2),new Potion("1",4),new Potion("2",0),new Potion("3",1)};
    
    public Sprite[] recipeResultImage;
    public CraftingSlot[] craftingSlots;

    public void OnClickSlot(CraftingSlot slot){
        if(slot.item is Harvestment){
            PlayerData.HarvestmentInventory.Add((Harvestment)(slot.item));
        } else if(slot.item is Melee){
            PlayerData.EnqueueMelee(PlayerData.craftMelee(slot.item.name));
        } else if(slot.item is Potion){
            PlayerData.EnqueuePotion(PlayerData.craftPotion(slot.item.name));
        }
        if(slot.index == 999){
            foreach(CraftingSlot craftingSlot in craftingSlots){
                craftingSlot.item = null;
                itemList[craftingSlot.index] = null;
                craftingSlot.gameObject.SetActive(false);   
            }
            slot.item = null;
            slot.gameObject.SetActive(false);
            checkCraftingTable();
        } else{
            slot.item = null;
            itemList[slot.index] = null;
            slot.gameObject.SetActive(false);
            checkCraftingTable();
        }

    }

    public void checkCraftingTable(){
        resultSlot.gameObject.SetActive(false);
        resultSlot.item = null;

        string currentRecipeString = "";
        foreach(Item item in itemList){
            if(item != null){
                currentRecipeString += item.name;
            }else{
                currentRecipeString += "null";
            }
        }

        for(int i = 0; i < recipes.Length; i++){
            if(recipes[i] == currentRecipeString){
                resultSlot.gameObject.SetActive(true);
                resultSlot.GetComponent<Image>().sprite = recipeResultImage[i];
                resultSlot.item = recipeResults[i];
                
            }
        }

    }
}
