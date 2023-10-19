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
        }
        if(Input.GetKeyUp(KeyCode.S)){
            move = new Vector3(0f,-moveSpeed,0f);
        }
        if(Input.GetKeyUp(KeyCode.A)){
            move = new Vector3(-moveSpeed,0f,0f);
        }
        if(Input.GetKeyUp(KeyCode.D)){
            move = new Vector3(moveSpeed,0f,0f);
        }
        if(move.x != 0f || move.y != 0f){
            if(Garden.canHarvest){
                if(PlayerData.mov <= 0){
                    Debug.Log("You ran out of movement.");
                    return;
                }
                PlayerData.mov--;
            }
            transform.position += move;
        }
        
        
    }
}
