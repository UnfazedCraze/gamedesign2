using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    public static Seed[,] seedInfo;
    public static bool canHarvest;
    public static int remainingRounds;
    public static Dictionary<string,int[,]> enemy_type_to_range;
    public static bool[,] gridOccupied;


    // Start is called before the first frame update
    public static void plantSeed(int posX,int posY,Seed seed){
        seedInfo[posX,posY] = seed;
    }

    public static Seed getSeed(int posX,int posY){
        return seedInfo[posX,posY];
    }
    void Start()
    {
        seedInfo = new Seed[12,12];
        canHarvest = false;
        remainingRounds = 20;
        
        InitializeGrid();
        InitializeEnemyRange();

    }

    void InitializeGrid(){
        gridOccupied = new bool[12,12];
        for(int i = 0; i < 12; i++){
            for( int j = 0; j < 12; j++){
                gridOccupied[i,j]=false;
            }
        }
    }

    void InitializeEnemyRange(){
        enemy_type_to_range = new Dictionary<string, int[,]>(); 
        enemy_type_to_range.Add("a",new int[9,9]{
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,1,1,1,0,0,0},
            {0,0,0,1,0,1,0,0,0},
            {0,0,0,1,1,1,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
        });
        enemy_type_to_range.Add("f",new int[9,9]{
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,1,1,1,0,0,0},
            {0,0,0,1,0,1,0,0,0},
            {0,0,0,1,1,1,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0}
        });

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
