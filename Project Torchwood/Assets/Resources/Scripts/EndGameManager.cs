using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject winningText;
    public GameObject NextLevelButton;
    public GameObject losingText;
    public GameObject OutOfRoundsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.HP <= 0 || Garden.homeHP <= 0){
            losingText.SetActive(true);
        }

        bool hasMoreEnemies = false;
        foreach(object[] row in Garden.tiles){
            foreach(object obj in row){
                if(obj!=null && obj is Enemy){
                    hasMoreEnemies = true;
                }
            }
        }

        if(Garden.canHarvest == true && !hasMoreEnemies){
            winningText.SetActive(true);
            NextLevelButton.SetActive(true);
        }
        
        
    }
}
