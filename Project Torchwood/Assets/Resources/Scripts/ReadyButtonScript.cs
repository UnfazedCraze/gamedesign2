using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyButtonScript : MonoBehaviour
{
    // public GameObject plantA;
    // public GameObject plantB;
    // public GameObject plantC;
    private GameObject[] seeds;
    private GameObject plantToBeGrown;
    // public GameObject smallMonster;
    public Vector2[] smallMonsterSpawnPos;
    public string[] smallMonsterTypes;
    public GameObject HarvestButtion;
    public GameObject NextRoundButton;
    public GameObject ReadyButton;
    public GameObject NightMask;
    public GameObject audio1;
    public GameObject audio2;
    // public GameObject RoundsLeftText;
    public void ReadyButtonOnClick(){
        PlayerData.AP = PlayerData.maxAP;
        audio1.SetActive(false);
        audio2.SetActive(true);
        HarvestButtion.SetActive(true);
        NextRoundButton.SetActive(true);
        NightMask.SetActive(true);
        // RoundsLeftText.SetActive(true);
        ReadyButton.SetActive(false);
        if(Garden.canHarvest){
            Debug.Log("You're already ready.");
            return;
        }

        for(int i = 0; i < smallMonsterSpawnPos.Length; i++){
            Vector2 pos = smallMonsterSpawnPos[i];
            Garden.tiles[(int)pos.x][(int)pos.y] = new Enemy(smallMonsterTypes[i]);
        }

        Garden.canHarvest = true;
        Garden.seedsGrow(5);
        Garden.reloadGarden();

        // seeds = GameObject.FindGameObjectsWithTag("Seed");
        // foreach(GameObject obj in seeds){
        //     int[] obj_pos = PlayerInteraction.getItemGrid(obj.transform.position.x,obj.transform.position.y);
        //     Vector2 plant_pos = obj.transform.position;
        //     GameObject.Destroy(obj);
        //     string seedName = Garden.seedInfo[obj_pos[0],obj_pos[1]].name;
        //     if(Equals(seedName,"a")){
        //         plantToBeGrown = plantA;
        //     } else if(Equals(seedName,"b")){
        //         plantToBeGrown = plantB;
        //     } else if(Equals(seedName,"c")){
        //         plantToBeGrown = plantC;
        //     } else{
        //         Debug.Log("Plant not unlocked.");
        //         return;
        //     }

        //     Instantiate(plantToBeGrown,plant_pos,Quaternion.identity);
        // }




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
