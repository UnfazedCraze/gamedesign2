using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int currentDialogueCount;
    public static string Name;
    public static int HP;
    public static int AP;

    public static List<Seed> SeedInventory;
    public static List<Plant> PlantInventory;
    public static Queue<Melee> MeleeInventory;
    public static List<Potion> PotionInventory;
    public static int mov;
    public static int maxmov;
    public static bool canAttack;
    public static bool canUseItem;
    public static string facingDirection;

// Crafts a melee with the given name
    public static Melee craftMelee(string name){
        int atk = 0;
        int durability = 0;
        if(Equals(name,"1")){
            atk = 2;
            durability = 5;
        }
        return new Melee(name,durability,atk);
    }


    public static Melee DequeueMelee(){
        Debug.Log("Dequeue");
        Debug.Log(MeleeInventory.Peek().name);
        return MeleeInventory.Dequeue();
    }

    public static void EnqueueMelee(Melee m){
        MeleeInventory.Enqueue(m);
        Debug.Log("Enqueue");
    }

    void Start(){
        PlayerData.HP = 15;
        PlayerData.AP = 15;
        PlayerData.maxmov = 4;
        PlayerData.mov = PlayerData.maxmov;
        PlayerData.canAttack = true;
        PlayerData.canUseItem = true;
        PlayerData.Name = "testPlayer1";
        PlayerData.SeedInventory = new List<Seed>();
        PlayerData.PlantInventory = new List<Plant>();
        PlayerData.MeleeInventory = new Queue<Melee>();
        PlayerData.PotionInventory = new List<Potion>();
        PlayerData.facingDirection = "Right";
        addStarterPack();


        currentDialogueCount = 0;
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
