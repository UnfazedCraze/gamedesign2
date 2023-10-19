using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyButtonScript : MonoBehaviour
{
    public GameObject plantA;
    public GameObject plantB;
    public GameObject plantC;
    private GameObject[] seeds;
    private GameObject plantToBeGrown;
    public GameObject smallMonster;
    public GameObject Boss;
    public Vector2[] smallMonsterSpawnPos;
    public Vector2 bossSpawnPos;
    public void ReadyButtonOnClick(){
        if(Garden.canHarvest){
            Debug.Log("You're already ready.");
            return;
        }
        Garden.canHarvest = true;
        seeds = GameObject.FindGameObjectsWithTag("Seed");
        foreach(GameObject obj in seeds){
            int[] obj_pos = PlayerInteraction.getItemGrid(obj.transform.position.x,obj.transform.position.y);
            Vector2 plant_pos = obj.transform.position;
            GameObject.Destroy(obj);
            string seedName = Garden.seedInfo[obj_pos[0],obj_pos[1]].name;
            if(Equals(seedName,"a")){
                plantToBeGrown = plantA;
            } else if(Equals(seedName,"b")){
                plantToBeGrown = plantB;
            } else if(Equals(seedName,"c")){
                plantToBeGrown = plantC;
            } else{
                Debug.Log("Plant not unlocked.");
                return;
            }

            Instantiate(plantToBeGrown,plant_pos,Quaternion.identity);
        }
        foreach(Vector2 pos in smallMonsterSpawnPos){
            Instantiate(smallMonster,pos,Quaternion.identity);
        }
        Instantiate(Boss,bossSpawnPos,Quaternion.identity);



    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
