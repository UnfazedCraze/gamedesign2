using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garden : MonoBehaviour
{
    // public static Seed[,] seedInfo;
    public static bool canHarvest;
    // public static int remainingRounds;
    public static Dictionary<string,int[,]> enemy_type_to_range;
    // public static bool[,] gridOccupied;
    public static object[][] tiles;
    public static GameObject[] seeds;
    public static GameObject[] plants;
    public static GameObject[] monsters;
    public static GameObject hptext;

    public static int homeHP;

    public static void reloadGarden(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Seed");
        foreach(GameObject obj in objects){
            GameObject.Destroy(obj);
        }
        objects = GameObject.FindGameObjectsWithTag("Plant");
        foreach(GameObject obj in objects){
            GameObject.Destroy(obj);
        }
        objects = GameObject.FindGameObjectsWithTag("Monster");
        foreach(GameObject obj in objects){
            GameObject.Destroy(obj);
        }
        for(int i = 0; i < tiles.Length; i++){
            for(int j = 0; j < tiles[i].Length; j++){
                if(tiles[i][j] != null){
                    Vector2 pos = PlayerInteraction.getPosWithGrid(new int[]{i,j});
                    if(tiles[i][j] is Seed){
                        Seed obj = (Seed)tiles[i][j];
                        if(Equals(obj.name,"a")){
                            Instantiate(seeds[0],pos,Quaternion.identity);
                        }else if(Equals(obj.name,"b")){
                            Instantiate(seeds[1],pos,Quaternion.identity);
                        }else if(Equals(obj.name,"c")){
                            Instantiate(seeds[2],pos,Quaternion.identity);
                        }else if(Equals(obj.name,"d")){
                            Instantiate(seeds[3],pos,Quaternion.identity);
                        }else if(Equals(obj.name,"e")){
                            Instantiate(seeds[4],pos,Quaternion.identity);
                        }
                    }else if(tiles[i][j] is Plant){
                        Plant obj = (Plant)tiles[i][j];
                        if(obj.hp == 0){
                            tiles[i][j]=null;
                            continue;
                        }
                        string text = obj.hp + "/" + obj.maxhp;
                        hptext.GetComponent<Text>().text=text;
                        Instantiate(hptext,pos,Quaternion.identity);
                        
                        // Debug.Log(i+" "+j);
                        if(Equals(obj.name,"a")){
                            if(!obj.harvested){
                                Instantiate(plants[0],pos,Quaternion.identity);
                            }else{
                                Instantiate(plants[5],pos,Quaternion.identity);
                            }
                        }else if(Equals(obj.name,"b")){
                            if(!obj.harvested){
                                Instantiate(plants[1],pos,Quaternion.identity);
                            }else{
                                Instantiate(plants[5],pos,Quaternion.identity);
                            }
                        }else if(Equals(obj.name,"c")){
                            if(!obj.harvested){
                                Instantiate(plants[2],pos,Quaternion.identity);
                            }else{
                                Instantiate(plants[5],pos,Quaternion.identity);
                            }
                        }else if(Equals(obj.name,"d")){
                            if(!obj.harvested){
                                Instantiate(plants[3],pos,Quaternion.identity);
                            }else{
                                Instantiate(plants[6],pos,Quaternion.identity);
                            }
                        }else if(Equals(obj.name,"e")){
                            if(!obj.harvested){
                                Instantiate(plants[4],pos,Quaternion.identity);
                            }else{
                                Instantiate(plants[7],pos,Quaternion.identity);
                            }
                        }
                    }else if(tiles[i][j] is Enemy){
                        Enemy obj = (Enemy)tiles[i][j];
                        if(obj.HP == 0){
                            tiles[i][j]=null;
                            continue;
                        }
                        string text = obj.HP + "/" + obj.maxHP;
                        if(Equals(obj.type,"a")){
                            Instantiate(monsters[0],pos,Quaternion.identity);
                        }else if(Equals(obj.type,"b")){
                            Instantiate(monsters[1],pos,Quaternion.identity);
                        }else if(Equals(obj.type,"c")){
                            Instantiate(monsters[2],pos,Quaternion.identity);
                        }else if(Equals(obj.type,"d")){
                            Instantiate(monsters[3],pos,Quaternion.identity);
                        }else if(Equals(obj.type,"e")){
                            Instantiate(monsters[4],pos,Quaternion.identity);
                        }else if(Equals(obj.type,"f")){
                            Instantiate(monsters[5],pos,Quaternion.identity);
                        }
                    }
                }
            }
        }




        // Instantiate(plantToBeGrown,plant_pos,Quaternion.identity);



    }




    public static void checkGrowth(){
        for(int i = 0; i < tiles.Length; i++){
            for(int j = 0; j < tiles[i].Length; j++){
                if(tiles[i][j] != null && tiles[i][j] is Seed){
                    Seed seed = (Seed)(tiles[i][j]);
                    if(seed.turnToGrow == 0){
                        tiles[i][j] = new Plant(seed.name);
                    }
                }
            }
        }
    }

    public static void seedsGrow(int turns){
        for(int i = 0; i < tiles.Length; i++){
            for(int j = 0; j < tiles[i].Length; j++){
                if(tiles[i][j] != null && tiles[i][j] is Seed){
                    Seed seed = (Seed)(tiles[i][j]);
                    seed.Grow(turns);
                }
            }
        }
        checkGrowth();
    }


    // Start is called before the first frame update
    public static void plantSeed(int posX,int posY,Seed seed){
        tiles[posX][posY]=seed;
        reloadGarden();
    }

    void Start()
    {
        homeHP = 10;
        tiles = new object[8][];
        for(int i = 0;i < 8; i++){
            tiles[i] = new object[8];
        }
        canHarvest = false;
        // remainingRounds = 20;
        
        // InitializeGrid();
        // InitializeEnemyRange();

    }

    // void InitializeGrid(){
    //     gridOccupied = new bool[12,12];
    //     for(int i = 0; i < 12; i++){
    //         for( int j = 0; j < 12; j++){
    //             gridOccupied[i,j]=false;
    //         }
    //     }
    // }

    // void InitializeEnemyRange(){
    //     enemy_type_to_range = new Dictionary<string, int[,]>(); 
    //     enemy_type_to_range.Add("a",new int[9,9]{
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,1,1,1,0,0,0},
    //         {0,0,0,1,0,1,0,0,0},
    //         {0,0,0,1,1,1,0,0,0},
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,0,0,0,0,0,0}
    //     });
    //     enemy_type_to_range.Add("f",new int[9,9]{
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,1,1,1,0,0,0},
    //         {0,0,0,1,0,1,0,0,0},
    //         {0,0,0,1,1,1,0,0,0},
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,0,0,0,0,0,0},
    //         {0,0,0,0,0,0,0,0,0}
    //     });

    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
