using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static string Name;
    public static int HP;
    public static int AP;

    public static List<Seed> SeedInventory;
    public static List<Plant> PlantInventory;
    public static List<Melee> MeleeInventory;
    public static List<Potion> PotionInventory;
    public static int mov;
    public static bool canAttack;
    public static bool canUseItem;



    void Start(){
        PlayerData.HP = 15;
        PlayerData.AP = 15;
        PlayerData.mov = 2;
        PlayerData.canAttack = true;
        PlayerData.canUseItem = true;
        PlayerData.Name = "testPlayer1";
        PlayerData.SeedInventory = new List<Seed>();
        PlayerData.PlantInventory = new List<Plant>();
        PlayerData.MeleeInventory = new List<Melee>();
        PlayerData.PotionInventory = new List<Potion>();
        addStarterPack();
    }

    public static Seed useSeed(string name){

        foreach(Seed s in SeedInventory){
            if(Equals(s.name,name)){
                if(AP < s.apcost){
                    Debug.Log("Not enough AP");
                    return null;
                }
                SeedInventory.Remove(s);
                AP -= s.apcost;
                return s;
            }
        }
        Debug.Log("No more seed A");
        return null;
    }

    void addStarterPack(){

        for(int i = 0; i < 5; i++){
            PlayerData.SeedInventory.Add(new Seed("a",2));
            PlayerData.SeedInventory.Add(new Seed("b",2));
            PlayerData.SeedInventory.Add(new Seed("c",2));
        }
    }

    void Update(){}

}
