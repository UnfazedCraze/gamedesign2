using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Item
{
    // public string name;
    public int durability;
    public int damage;

    public Melee(string name, int durability, int damage){
        this.name = name;
        this.durability = durability;
        this.damage = damage;
    }
}
