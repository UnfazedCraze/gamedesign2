using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // public Transform movePoint;
    private float moveSpeed;
    public GameObject MeleeSlot;
    public GameObject PotionSlot;

    // public float speed;
    // private Rigidbody2D rb;
    // private float inputX, inputY;

    
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        // movePoint.parent = null;
        moveSpeed = 0.9f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position, movePoint.position,moveSpeed);
        // inputX = Input.GetAxisRaw("Horizontal");
        // inputY = Input.GetAxisRaw("Vertical");
        // Vector2 input = new Vector2(inputX, inputY).normalized;
        // rb.velocity = input*speed;
        Vector3 move = new Vector3(0f,0f,0f);
        int x = PlayerInteraction.getPlayerGrid()[0];
        int y = PlayerInteraction.getPlayerGrid()[1];
        if(Input.GetKeyUp(KeyCode.W)){
            // Debug.Log(PlayerInteraction.player.position.x+" "+PlayerInteraction.player.position.y);
            // Debug.Log(PlayerInteraction.getPlayerGrid()[0]+" "+PlayerInteraction.getPlayerGrid()[1]);
            if(y==0){
                return;
            }
            if(Garden.tiles[x][y-1]!=null && !(Garden.tiles[x][y-1] is Seed)){
                Debug.Log("Way blocked");
                return;
            }
            move = new Vector3(0f,moveSpeed,0f);
            PlayerData.facingDirection = "Up";
        }
        if(Input.GetKeyUp(KeyCode.S)){
            if(y==7){
                return;
            }
            if(Garden.tiles[x][y+1]!=null && !(Garden.tiles[x][y+1] is Seed)){
                Debug.Log("Way blocked");
                return;
            }
            move = new Vector3(0f,-moveSpeed,0f);
            PlayerData.facingDirection = "Down";
        }
        if(Input.GetKeyUp(KeyCode.A)){
            if(x==0){
                return;
            }
            if(Garden.tiles[x-1][y]!=null && !(Garden.tiles[x-1][y] is Seed)){
                Debug.Log("Way blocked");
                return;
            }
            move = new Vector3(-moveSpeed,0f,0f);
            PlayerData.facingDirection = "Left";
        }
        if(Input.GetKeyUp(KeyCode.D)){
            if(x==7){
                return;
            }
            if(Garden.tiles[x+1][y]!=null && !(Garden.tiles[x+1][y] is Seed)){
                Debug.Log("Way blocked");
                return;
            }
            move = new Vector3(moveSpeed,0f,0f);
            PlayerData.facingDirection = "Right";
        }
        if(move.x != 0f || move.y != 0f){
            Debug.Log(PlayerData.facingDirection);
            if(Garden.canHarvest){
                if(!PlayerData.consumeAP(1)){
                    Debug.Log("You ran out of movement.");
                    return;
                }
            }
            transform.position += move;
        }
        //Press Q and E to circle around your melee inventory
        if(Input.GetKeyUp(KeyCode.E)){
            if(MeleeSlot.activeSelf){
                if(PlayerData.MeleeInventory.Count != 0){
                    Melee temp = PlayerData.DequeueMelee();
                    PlayerData.EnqueueMelee(temp);
                }
            }else{
                if(PlayerData.PotionInventory.Count != 0){
                    Potion temp = PlayerData.DequeuePotion();
                    PlayerData.EnqueuePotion(temp);
                }
            }
            
        }
        if(Input.GetKeyUp(KeyCode.Q)){
            if(MeleeSlot.activeSelf){
                if(PlayerData.MeleeInventory.Count != 0){
                    for(int i = 0; i < PlayerData.MeleeInventory.Count-1; i++){
                        Melee temp = PlayerData.DequeueMelee();
                        PlayerData.EnqueueMelee(temp);
                    }

                }
            }else{
                if(PlayerData.PotionInventory.Count != 0){
                    for(int i = 0; i < PlayerData.PotionInventory.Count-1; i++){
                        Potion temp = PlayerData.DequeuePotion();
                        PlayerData.EnqueuePotion(temp);
                    }

                }
            }
            
        }
        if(Input.GetKeyUp(KeyCode.Tab)){
            if(MeleeSlot.activeSelf){
                MeleeSlot.SetActive(false);
                PotionSlot.SetActive(true);
            }else{
                MeleeSlot.SetActive(true);
                PotionSlot.SetActive(false);
            }
        }
    }
}
