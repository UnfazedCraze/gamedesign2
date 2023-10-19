using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedButtonScript : MonoBehaviour
{
    public GameObject seedInstance;
    public string seedName;
    public void plantSeed(){
        if(Garden.canHarvest){
            Debug.Log("It's not the time for planting.");
            return;
        }
        PlayerInteraction.plantSeed(seedName,seedInstance);
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
