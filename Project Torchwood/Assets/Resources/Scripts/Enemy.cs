using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string type;
    public int HP;
    public int attack;
    public int maxmov;
    public int mov;

    public Enemy(string type,int HP,int attack,int maxmov){
        this.type = type;
        this.HP = HP;
        this.attack = attack;
        this.maxmov = maxmov;
        this.mov = maxmov;
    }

    public void takeDamage(int damage){
        HP -= damage;
    }

    void Update(){

    }
}
