using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string type;
    public int HP;
    public int attack;
    public int mov;

    public Enemy(string type,int HP,int attack,int mov){
        this.type = type;
        this.HP = HP;
        this.attack = attack;
        this.mov = mov;
    }

    public void takeDamage(int damage){
        HP -= damage;
    }

    void Update(){

    }
}
