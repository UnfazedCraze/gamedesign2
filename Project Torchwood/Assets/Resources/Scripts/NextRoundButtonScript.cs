using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextRoundButtonScript : MonoBehaviour
{
    public void NextRoundButtonScriptOnClick(){
        // Garden.remainingRounds--;
        // if(Garden.remainingRounds <= 0){
        //     Debug.Log("The night has passed. The monsters have left.");
        //     return;
        // }
        PlayerData.AP = PlayerData.maxAP;
        Garden.seedsGrow(1);
        PlayerData.canAttack = true;
        PlayerData.canUseItem = true;
        for(int i = 0; i < Garden.tiles.Length;i++){
            for(int j = 0; j < Garden.tiles[i].Length; j++){
                object obj = Garden.tiles[i][j];
                if(obj == null){
                    continue;
                }
                if(obj is Enemy){
                    ((Enemy)obj).mov = ((Enemy)obj).maxmov;
                }
            }
        }
        for(int i = 0; i < Garden.tiles.Length;i++){
            for(int j = 0; j < Garden.tiles[i].Length; j++){
                object obj = Garden.tiles[i][j];
                if(obj == null){
                    continue;
                }
                if(obj is Plant){
                    PlantMovement(i,j);
                    Garden.reloadGarden();
                }
                if(obj is Enemy){
                    MonsterMovement(i,j);
                    Garden.reloadGarden();
                }
            }
        }
        Garden.reloadGarden();
    }

    public void PlantMovement(int x,int y){
        Plant p = (Plant)Garden.tiles[x][y];
        int range = p.range;
        if(!p.harvested){
            return;
        }
        Debug.Log("Plant move");
        int lowx = 0;
        int highx = 7;
        int lowy = 0;
        int highy = 7;
        if(x-range > 0){
            lowx = x-range;
        }
        if(x+range > 0){
            highx = x+range;
        }
        if(y-range > 0){
            lowy = y-range;
        }
        if(y+range > 0){
            highy = y+range;
        }
        for(int i = lowx; i <= highx;i++){
            for(int j = lowy; j <= highy; j++){
                if(Garden.tiles[i][j]!=null && Garden.tiles[i][j] is Enemy){
                    ((Enemy)Garden.tiles[i][j]).takeDamage(p.atk);
                    return;
                }
            }
        }
    }

    public void MonsterMovement(int x, int y){
        Enemy e = (Enemy)Garden.tiles[x][y];
        if(e.isFrozen){
            e.isFrozen = false;
            return;
        }
        int[] PlayerGrid = PlayerInteraction.getPlayerGrid();
        if(Equals(e.type,"a")||Equals(e.type,"c")||Equals(e.type,"e")){
            //goes for the player
            while(e.mov > 0){
                bool moved = false;
                if(Math.Abs(PlayerGrid[1]-y)>1){
                    if(PlayerGrid[1]>y){
                        if(Garden.tiles[x][y+1]==null){
                            Garden.tiles[x][y+1]=e;
                            Garden.tiles[x][y]=null;
                            e.mov--;
                            y++;
                            moved = true;
                        }
                    }else{
                        if(Garden.tiles[x][y-1]==null){
                            Garden.tiles[x][y-1]=e;
                            Garden.tiles[x][y]=null;
                            e.mov--;
                            y--;
                            moved = true;
                        }
                    }
                }
                if(e.mov == 0){
                    break;
                }
                if(Math.Abs(PlayerGrid[0]-x)>1){
                    if(PlayerGrid[0]>x){
                        if(Garden.tiles[x+1][y]==null){
                            Garden.tiles[x+1][y]=e;
                            Garden.tiles[x][y]=null;
                            e.mov--;
                            x++;
                            moved = true;
                        }
                    }else{
                        if(Garden.tiles[x-1][y]==null){
                            Garden.tiles[x-1][y]=e;
                            Garden.tiles[x][y]=null;
                            e.mov--;
                            x--;
                            moved = true;
                        }
                    }
                }
                if(!moved){
                    break;
                }
            }
            int range = e.range;
            int lowx = 0;
            int highx = 7;
            int lowy = 0;
            int highy = 7;
            if(x-range > 0){
                lowx = x-range;
            }
            if(x+range > 0){
                highx = x+range;
            }
            if(y-range > 0){
                lowy = y-range;
            }
            if(y+range > 0){
                highy = y+range;
            }
            if(Math.Abs(PlayerGrid[0]-x)<=range && Math.Abs( PlayerGrid[1]-y)<=range){
                PlayerData.HP -= e.attack;
                return;
            }
            for(int i = lowx; i <= highx;i++){
                for(int j = lowy; j <= highy; j++){
                    if(Garden.tiles[i][j]!=null && Garden.tiles[i][j] is Plant){
                        Debug.Log("Attack plant");
                        ((Plant)Garden.tiles[i][j]).takeDamage(e.attack);
                        return;
                    }
                }
            }
            
        }else if(Equals(e.type,"b")||Equals(e.type,"d")){
            //goes for the home
            while(e.mov > 0){
                Debug.Log(e.mov);
                bool moved = false;
                if(Math.Abs(3.5-y)>1){
                    if(3>y){
                        if(Garden.tiles[x][y+1]==null){
                            e.mov--;
                            Garden.tiles[x][y+1]=e;
                            Garden.tiles[x][y]=null;
                            y++;
                            moved = true;
                        }
                    }else{
                        if(Garden.tiles[x][y-1]==null){
                            e.mov--;
                            Garden.tiles[x][y-1]=e;
                            Garden.tiles[x][y]=null;
                            y--;
                            moved = true;
                        }
                    }
                }
                if(e.mov == 0){
                    break;
                }
                if(Math.Abs(7-x)>1){
                    if(7>x){
                        if(Garden.tiles[x+1][y]==null){
                            e.mov--;
                            Garden.tiles[x+1][y]=e;
                            Garden.tiles[x][y]=null;
                            x++;
                            moved = true;
                        }
                    }else{
                        if(Garden.tiles[x-1][y]==null){
                            e.mov--;
                            Garden.tiles[x-1][y]=e;
                            Garden.tiles[x][y]=null;
                            x--;
                            moved = true;
                        }
                    }
                }
                if(!moved){
                    break;
                }
            }
            if((x==7||x==6)&&(y==2||y==3||y==4||y==5)){
                Garden.homeHP-=e.attack;
                return;
            }
            int range = e.range;
            int lowx = 0;
            int highx = 7;
            int lowy = 0;
            int highy = 7;
            if(x-range > 0){
                lowx = x-range;
            }
            if(x+range > 0){
                highx = x+range;
            }
            if(y-range > 0){
                lowy = y-range;
            }
            if(y+range > 0){
                highy = y+range;
            }
            if(Math.Abs(PlayerGrid[0]-x)<=range && Math.Abs( PlayerGrid[1]-y)<=range){
                PlayerData.HP -= e.attack;
                return;
            }
            for(int i = lowx; i <= highx;i++){
                for(int j = lowy; j <= highy; j++){
                    if(Garden.tiles[i][j]!=null && Garden.tiles[i][j] is Plant){
                        Debug.Log("Attack plant");
                        ((Plant)Garden.tiles[i][j]).takeDamage(e.attack);
                        return;
                    }
                }
            }

            

        }else if(Equals(e.type,"f")){
            //ranged attack goes for the player
            
             while(e.mov > 0){
                int range = e.range;
                int lowx = 0;
                int highx = 7;
                int lowy = 0;
                int highy = 7;
                if(x-range > 0){
                    lowx = x-range;
                }
                if(x+range > 0){
                    highx = x+range;
                }
                if(y-range > 0){
                    lowy = y-range;
                }
                if(y+range > 0){
                    highy = y+range;
                }
                if(Math.Abs(PlayerGrid[0]-x)<=range && Math.Abs( PlayerGrid[1]-y)<=range){
                    PlayerData.HP -= e.attack;
                    return;
                }
                bool moved = false;
                if(Math.Abs(PlayerGrid[1]-y)>1){
                    if(PlayerGrid[1]>y){
                        if(Garden.tiles[x][y+1]==null){
                            Garden.tiles[x][y+1]=e;
                            Garden.tiles[x][y]=null;
                            e.mov--;
                            y++;
                            moved = true;
                        }
                    }else{
                        if(Garden.tiles[x][y-1]==null){
                            Garden.tiles[x][y-1]=e;
                            Garden.tiles[x][y]=null;
                            e.mov--;
                            y--;
                            moved = true;
                        }
                    }
                }
                if(e.mov == 0){
                    break;
                }
                if(Math.Abs(PlayerGrid[0]-x)>1){
                    if(PlayerGrid[0]>x){
                        if(Garden.tiles[x+1][y]==null){
                            Garden.tiles[x+1][y]=e;
                            Garden.tiles[x][y]=null;
                            e.mov--;
                            x++;
                            moved = true;
                        }
                    }else{
                        if(Garden.tiles[x-1][y]==null){
                            Garden.tiles[x-1][y]=e;
                            Garden.tiles[x][y]=null;
                            e.mov--;
                            x--;
                            moved = true;
                        }
                    }
                }
                if(!moved){
                    break;
                }
            }

        }
        Debug.Log("Monster move");
        for(int i = 0; i < Garden.tiles.Length;i++){
            for(int j = 0; j < Garden.tiles[i].Length; j++){
            }
        }
    }

    // public void MonsterMovement(GameObject monster){
    //     Enemy enemy = monster.GetComponent<Enemy>();
    //     Vector2 pos = monster.transform.position;
    //     int[] monsterGrid = PlayerInteraction.getItemGrid(pos.x,pos.y);
    //     // Garden.gridOccupied[monsterGrid[0],monsterGrid[1]] = false;
    //     int[] playerGrid = PlayerInteraction.getPlayerGrid();
    //     int[] targetGrid = null;
    //     while(enemy.mov > 0){ 
    //         if(monsterGrid[0]-playerGrid[0]>0){
    //             if(!PlayerInteraction.gridOccupied(monsterGrid[0]-1,monsterGrid[1])){
    //                 targetGrid = new int[]{monsterGrid[0]-1,monsterGrid[1]};
    //             }
    //         } 
    //         if(monsterGrid[0]-playerGrid[0]<0){
    //             if(!PlayerInteraction.gridOccupied(monsterGrid[0]+1,monsterGrid[1])){
    //                 targetGrid = new int[]{monsterGrid[0]+1,monsterGrid[1]};
    //             }
    //         } 
    //         if(monsterGrid[1]-playerGrid[1]>0){
    //             if(!PlayerInteraction.gridOccupied(monsterGrid[0],monsterGrid[1]-1)){
    //                 targetGrid = new int[]{monsterGrid[0],monsterGrid[1]-1};
    //             }
    //         } 
    //         if(monsterGrid[1]-playerGrid[1]<0){
    //             if(!PlayerInteraction.gridOccupied(monsterGrid[0],monsterGrid[1]+1)){
    //                 targetGrid = new int[]{monsterGrid[0],monsterGrid[1]+1};
    //             }
    //         } 
    //         if(targetGrid!=null){
    //             monster.transform.position = PlayerInteraction.getPosWithGrid(targetGrid);
    //         }
    //         pos = monster.transform.position;
    //         monsterGrid = PlayerInteraction.getItemGrid(pos.x,pos.y);
    //         // Garden.gridOccupied[monsterGrid[0],monsterGrid[1]] = false;
    //         enemy.mov --;
    //     }
        
    //     if(Mathf.Abs(monsterGrid[0]-playerGrid[0])<=1 && Mathf.Abs(monsterGrid[1]-playerGrid[1])<=1){
    //         PlayerData.HP -= enemy.attack;
    //     }

    // }

}
