using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed
{
    public string name;
    public int apcost;
    public int turnToGrow;
    public Seed(string name){
        this.name = name;
        if(Equals(name,"a")){
            apcost = 2;
            turnToGrow = 5;
        } else if(Equals(name,"b")){
            apcost = 2;
            turnToGrow = 5;
        } else if(Equals(name,"c")){
            apcost = 4;
            turnToGrow = 5;
        } else if(Equals(name,"d")){
            apcost = 3;
            turnToGrow = 15;
        } else if(Equals(name,"e")){
            apcost = 3;
            turnToGrow = 8;
        } else{
            Debug.Log("Name unfound");
            return;
        }
    }

    public void Grow(int turns){
        if(turnToGrow<=turns){
            turnToGrow = 0;
        }else{
            turnToGrow -= turns;
        }
    }
}
