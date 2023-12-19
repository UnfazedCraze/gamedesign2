using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static int currentDialogueCount;
    public static string Name;
    public static int HP;
    public static int AP;
    public static int maxAP;

    public static List<Seed> SeedInventory;
    public static List<Harvestment> HarvestmentInventory;
    public static Queue<Melee> MeleeInventory;
    public static Queue<Potion> PotionInventory;
    // public static int mov;
    // public static int maxmov;
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
        }else if(Equals(name,"2")){
            atk = 3;
            durability = 8;
        }else if(Equals(name,"3")){
            atk = 2;
            durability = 12;
        }
        return new Melee(name,durability,atk);
    }

    public static Potion craftPotion(string name){
        int atk = 0;
        if(Equals(name,"1")){
            atk = 4;
        }else if(Equals(name,"2")){
            atk = 0;
        }else if(Equals(name,"3")){
            atk = 1;
        }
        return new Potion(name,atk);
    }

    public static bool consumeAP(int AP){
        if(PlayerData.AP < AP){
            return false;
        }
        PlayerData.AP -= AP;
        return true;
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
    public static Potion DequeuePotion(){
        Debug.Log("Dequeue");
        Debug.Log(PotionInventory.Peek().name);
        return PotionInventory.Dequeue();
    }

    public static void EnqueuePotion(Potion p){
        PotionInventory.Enqueue(p);
        Debug.Log("Enqueue");
    }

    void Start(){
        PlayerData.HP = 15;
        PlayerData.maxAP = 21+SceneManager.GetActiveScene().buildIndex*3;
        PlayerData.AP = PlayerData.maxAP;
        // PlayerData.maxmov = 4;
        // PlayerData.mov = PlayerData.maxmov;
        PlayerData.canAttack = true;
        PlayerData.canUseItem = true;
        PlayerData.Name = "testPlayer1";
        PlayerData.SeedInventory = new List<Seed>();
        PlayerData.HarvestmentInventory = new List<Harvestment>();
        PlayerData.MeleeInventory = new Queue<Melee>();
        PlayerData.PotionInventory = new Queue<Potion>();
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
            PlayerData.SeedInventory.Add(new Seed("a"));
            PlayerData.SeedInventory.Add(new Seed("b"));
            PlayerData.SeedInventory.Add(new Seed("c"));
            if(SceneManager.GetActiveScene().buildIndex>=2){
                PlayerData.SeedInventory.Add(new Seed("d"));
            }
            if(SceneManager.GetActiveScene().buildIndex>=3){
                PlayerData.SeedInventory.Add(new Seed("e"));
            }
            
        }
    }

    void Update(){}

}
