using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestButtonScript : MonoBehaviour
{
    private GameObject[] harvestables;
    public void HarvestButtonOnClick(){
        if(!Garden.canHarvest){
            Debug.Log("Cannot harvest yet.");
            return;
        }
        int[] playerGrid = PlayerInteraction.getPlayerGrid();
        Vector2 harvestPos = PlayerInteraction.getPosWithGrid(playerGrid);

        harvestables = GameObject.FindGameObjectsWithTag("Harvestable");
        foreach(GameObject obj in harvestables){
            if(obj.transform.position.x == harvestPos.x && obj.transform.position.y == harvestPos.y){
                GameObject.Destroy(obj);
                PlayerData.PlantInventory.Add(new Plant(Garden.seedInfo[playerGrid[0],playerGrid[1]].name));
                Garden.seedInfo[playerGrid[0],playerGrid[1]] = null;
                return;
            }
        }
        Debug.Log("Nothing in this tile to be harvested.");
        


    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
