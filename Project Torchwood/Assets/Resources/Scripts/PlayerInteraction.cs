using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static Transform player;

    public static bool gridOccupied(int gridx, int gridy){
        if(gridx==getPlayerGrid()[0]&&gridy==getPlayerGrid()[1]){
            Debug.Log("Grid occupied");
            return true;
        } else{
            GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
            foreach(GameObject monster in monsters){
                Vector2 pos = monster.transform.position;
                int[] monsterGrid = getItemGrid(pos.x,pos.y);
                if(gridx==monsterGrid[0]&&gridy==monsterGrid[1]){
                    Debug.Log("Grid occupied");
                    return true;
                }
            }
        }
        return false;

    }

    // This method returns which grid the player is on
    public static int[] getPlayerGrid(){
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        
        int playerGridX = (int)((player.position.x+(double)3.6)/0.9);
        int playerGridY = (int)(8-(player.position.y+(double)3.6)/0.9);

        return new int[]{playerGridX,playerGridY};
    }
    public static int[] getItemGrid(double x, double y){
        
        int itemGridX = (int)((x+(double)3.6)/0.9);
        int itemGridY = (int)(8-(y+(double)3.6)/0.9);

        return new int[]{itemGridX,itemGridY};
    }

    //This method returns the position at the center of the grid.
    public static Vector2 getPosWithGrid(int[] grid){
        float posX = (float)(grid[0]*0.9-3.15);
        float posY = (float)(3.15-grid[1]*0.9);
        return new Vector2(posX,posY);
    }
    public static void plantSeed(string seedName){
        
        if(player.position.x>3.6 || player.position.x<-3.6 || player.position.y>3.6 || player.position.y<-3.6){
            Debug.Log("Cannot plant outside the garden.");
            return;
        }
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        int[] playerGrid = getPlayerGrid();

        Debug.Log(playerGrid[0]+" "+playerGrid[1]);
        if(Garden.tiles[playerGrid[0]][playerGrid[1]]!=null){
            Debug.Log("A seed already planted here.");
            return;
        }


        Seed plantedSeed = PlayerData.useSeed(seedName);
        if(plantedSeed == null){
            return;
        }
        Garden.plantSeed(playerGrid[0],playerGrid[1],plantedSeed);
        

        // Vector2 seedPos = getPosWithGrid(playerGrid);

        // Instantiate(seedInstance,seedPos,Quaternion.identity);

    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
