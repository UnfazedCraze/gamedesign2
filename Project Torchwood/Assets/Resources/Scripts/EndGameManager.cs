using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public GameObject winningText;
    public GameObject losingText;
    public GameObject OutOfRoundsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.HP <= 0){
            losingText.SetActive(true);
        }
        if(Garden.canHarvest == true && GameObject.FindGameObjectsWithTag("Monster").Length == 0){
            winningText.SetActive(true);
        }
        if(Garden.remainingRounds <= 0){
            OutOfRoundsText.SetActive(true);
        }
        
    }
}
