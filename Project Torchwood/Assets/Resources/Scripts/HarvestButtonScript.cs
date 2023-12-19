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
        if(!PlayerData.consumeAP(3)){
            Debug.Log("Not enough AP.");
            return;
        }
        int[] playerGrid = PlayerInteraction.getPlayerGrid();
        Vector2 harvestPos = PlayerInteraction.getPosWithGrid(playerGrid);

        
        for(int i = 0; i < Garden.tiles.Length;i++){
            for(int j = 0; j < Garden.tiles[i].Length;j++){
                // Debug.Log(i+" "+j+" "+Garden.tiles.Length+" "+Garden.tiles[i].Length);
                if(Garden.tiles[i][j] == null){
                    continue;
                }
                Debug.Log("Something");
                int[] grid = PlayerInteraction.getItemGrid(harvestPos.x,harvestPos.y);
                if(!(Mathf.Abs(i-grid[0])>1 || Mathf.Abs(j-grid[1])>1)){
                    if(Garden.tiles[i][j] is Plant){
                        Debug.Log("Harvest");
                        Plant plant = (Plant)Garden.tiles[i][j];
                        plant.harvest();
                    }
                }
            }
        }
        Garden.reloadGarden();



        // harvestables = GameObject.FindGameObjectsWithTag("Harvestable");
        // foreach(GameObject obj in harvestables){
        //     if(obj.transform.position.x == harvestPos.x && obj.transform.position.y == harvestPos.y){
        //         GameObject.Destroy(obj);
        //         PlayerData.PlantInventory.Add(new Plant(Garden.seedInfo[playerGrid[0],playerGrid[1]].name));
        //         Garden.seedInfo[playerGrid[0],playerGrid[1]] = null;
        //         return;
        //     }
        // }
        // Debug.Log("Nothing in this tile to be harvested.");
        


    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.HarvestmentInventory.Add(new Harvestment("a"));
        PlayerData.HarvestmentInventory.Add(new Harvestment("b"));
        PlayerData.HarvestmentInventory.Add(new Harvestment("c"));
        PlayerData.HarvestmentInventory.Add(new Harvestment("c"));

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
