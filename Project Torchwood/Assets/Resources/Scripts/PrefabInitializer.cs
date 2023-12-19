using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInitializer : MonoBehaviour
{
    public GameObject[] seeds;
    public GameObject[] plants;
    public GameObject[] monsters;
    public GameObject hptext;
    // Start is called before the first frame update
    void Start()
    {
        Garden.seeds = seeds;
        Garden.plants = plants;
        Garden.monsters = monsters;
        Garden.hptext = hptext;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
