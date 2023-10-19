using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    // public string name;
    public int damage;

    public Potion(string name, int damage){
        this.name = name;
        this.damage = damage;
    }
}
