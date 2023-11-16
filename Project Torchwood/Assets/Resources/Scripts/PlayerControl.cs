using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // public Transform movePoint;
    private float moveSpeed;

    // public float speed;
    // private Rigidbody2D rb;
    // private float inputX, inputY;

    
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        // movePoint.parent = null;
        moveSpeed = 0.6f;
        
        
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
        if(Input.GetKeyUp(KeyCode.W)){
            move = new Vector3(0f,moveSpeed,0f);
            PlayerData.facingDirection = "Up";
        }
        if(Input.GetKeyUp(KeyCode.S)){
            move = new Vector3(0f,-moveSpeed,0f);
            PlayerData.facingDirection = "Down";
        }
        if(Input.GetKeyUp(KeyCode.A)){
            move = new Vector3(-moveSpeed,0f,0f);
            PlayerData.facingDirection = "Left";
        }
        if(Input.GetKeyUp(KeyCode.D)){
            move = new Vector3(moveSpeed,0f,0f);
            PlayerData.facingDirection = "Right";
        }
        if(move.x != 0f || move.y != 0f){
            Debug.Log(PlayerData.facingDirection);
            if(Garden.canHarvest){
                if(PlayerData.mov <= 0){
                    Debug.Log("You ran out of movement.");
                    return;
                }
                PlayerData.mov--;
            }
            transform.position += move;
        }
        //Press Q and E to circle around your melee inventory
        if(Input.GetKeyUp(KeyCode.E)){
            if(PlayerData.MeleeInventory.Count != 0){
                // Debug.Log(PlayerData.MeleeInventory.Count);
                // Debug.Log(PlayerData.MeleeInventory.Peek().durability);
                Melee temp = PlayerData.DequeueMelee();
                // Debug.Log(PlayerData.MeleeInventory.Count);
                // Debug.Log(PlayerData.MeleeInventory.Peek().durability);
                // Debug.Log(temp.durability);
                PlayerData.EnqueueMelee(temp);
                // Debug.Log(PlayerData.MeleeInventory.Count);
                // Debug.Log(PlayerData.MeleeInventory.Peek().durability);
            }
        }
        if(Input.GetKeyUp(KeyCode.Q)){
            if(PlayerData.MeleeInventory.Count != 0){
                for(int i = 0; i < PlayerData.MeleeInventory.Count-1; i++){
                    Melee temp = PlayerData.DequeueMelee();
                    PlayerData.EnqueueMelee(temp);
                }

            }
        }
        
    }
}
