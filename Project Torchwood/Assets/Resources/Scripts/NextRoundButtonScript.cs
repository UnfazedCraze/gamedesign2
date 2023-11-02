using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoundButtonScript : MonoBehaviour
{
    public void NextRoundButtonScriptOnClick(){
        Garden.remainingRounds--;
        if(Garden.remainingRounds <= 0){
            Debug.Log("The night has passed. The monsters have left.");
            return;
        }
        PlayerData.mov = PlayerData.maxmov;
        PlayerData.canAttack = true;
        PlayerData.canUseItem = true;
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach(GameObject monster in monsters){
            monster.GetComponent<Enemy>().mov = monster.GetComponent<Enemy>().maxmov;
            MonsterMovement(monster);
        }
    }

    public void MonsterMovement(GameObject monster){
        Vector2 pos = monster.transform.position;
        int[] monsterGrid = PlayerInteraction.getItemGrid(pos.x,pos.y);
        int[] playerGrid = PlayerInteraction.getPlayerGrid();
        int[] targetGrid = null;
        while(monster.GetComponent<Enemy>().mov > 0){
            if(monsterGrid[0]-playerGrid[0]>0){
                if(!PlayerInteraction.gridOccupied(monsterGrid[0]-1,monsterGrid[1])){
                    targetGrid = new int[]{monsterGrid[0]-1,monsterGrid[1]};
                }
            } 
            if(monsterGrid[0]-playerGrid[0]<0){
                if(!PlayerInteraction.gridOccupied(monsterGrid[0]+1,monsterGrid[1])){
                    targetGrid = new int[]{monsterGrid[0]+1,monsterGrid[1]};
                }
            } 
            if(monsterGrid[1]-playerGrid[1]>0){
                if(!PlayerInteraction.gridOccupied(monsterGrid[0],monsterGrid[1]-1)){
                    targetGrid = new int[]{monsterGrid[0],monsterGrid[1]-1};
                }
            } 
            if(monsterGrid[1]-playerGrid[1]<0){
                if(!PlayerInteraction.gridOccupied(monsterGrid[0],monsterGrid[1]+1)){
                    targetGrid = new int[]{monsterGrid[0],monsterGrid[1]+1};
                }
            } 
            if(targetGrid!=null){
                monster.transform.position = PlayerInteraction.getPosWithGrid(targetGrid);
            }
            pos = monster.transform.position;
            monsterGrid = PlayerInteraction.getItemGrid(pos.x,pos.y);
            monster.GetComponent<Enemy>().mov --;
        }
        
        if(Mathf.Abs(monsterGrid[0]-playerGrid[0])<=1 && Mathf.Abs(monsterGrid[1]-playerGrid[1])<=1){
            PlayerData.HP -= monster.GetComponent<Enemy>().attack;
        }

    }

}
