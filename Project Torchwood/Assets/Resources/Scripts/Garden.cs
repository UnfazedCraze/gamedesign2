using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{
    public static Seed[,] seedInfo;
    public static bool canHarvest;
    public static int remainingRounds;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
