using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : Item
{

    public string type;
    public int HP;
    public int maxHP;
    public int attack;
    public int maxmov;
    public int mov;
    public int range;
    public bool isFrozen;


    public Enemy(string type){
        this.type = type;
        if(Equals(type,"a")){
            maxHP = 3;
            HP = 3;
            attack = 1;
            maxmov = 2;
            mov = 2;
            range = 1;
        }else if(Equals(type,"b")){
            maxHP = 4;
            HP = 4;
            attack = 2;
            maxmov = 2;
            mov = 2;
            range = 1;
        }else if(Equals(type,"c")){
            maxHP = 4;
            HP = 4;
            attack = 1;
            maxmov = 2;
            mov = 2;
            range = 1;
        }else if(Equals(type,"d")){
            maxHP = 6;
            HP = 6;
            attack = 3;
            maxmov = 1;
            mov = 1;
            range = 3;
        }else if(Equals(type,"e")){
            maxHP = 15;
            HP = 15;
            attack = 5;
            maxmov = 1;
            mov = 1;
            range = 1;
        }else if(Equals(type,"f")){
            maxHP = 4;
            HP = 4;
            attack = 1;
            maxmov = 1;
            mov = 1;
            range = 4;
        }
        
        // this.range = Garden.enemy_type_to_range[type];


    }

    public void takeDamage(int damage){
        if(HP < damage){
            HP = 0;
            return;
        }
        HP -= damage;
    }


}
