using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Item
{
    public int atk;
    public int maxhp;
    public int hp;
    public int range;
    public bool harvested;

    // public string name;
    public Plant(string name){
        this.name = name;
        harvested = false;
        if(Equals(name,"a")||Equals(name,"b")||Equals(name,"c")){
            atk = 1;
            maxhp = 2;
            hp = 2;
            range = 2;
        }else if(Equals(name,"d")){
            atk = 3;
            maxhp = 3;
            hp = 3;
            range = 4;
        }else if(Equals(name,"e")){
            atk = 0;
            maxhp = 4;
            hp = 4;
            range = 1;
        }
    }

    public void takeDamage(int damage){
        if(hp<damage){
            hp = 0;
        }else{
            hp -= damage;
        }
    }

    public void harvest(){
        if(!harvested){
            Debug.Log("Add");
            PlayerData.HarvestmentInventory.Add(new Harvestment(this.name));
            harvested = true;
        }
    }
}
