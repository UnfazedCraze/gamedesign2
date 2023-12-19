using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeSlotScript : MonoBehaviour
{
    public Image customCursor;
    private GameObject currentItem;

    public void onMouseDown(GameObject item){
        if(currentItem == null){
            currentItem = item;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = currentItem.GetComponent<Image>().sprite;
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)){
            if(currentItem != null){
                customCursor.gameObject.SetActive(false);
                Vector2 mousePos = Input.mousePosition;
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                float shortestDistance = float.MaxValue;

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
                GameObject target = null;
                foreach(GameObject enemy in enemies){
                    // Debug.Log(worldPos+"     "+enemy.transform.position);
                    float dist = Vector2.Distance(enemy.transform.position,worldPos);
                    if(dist<shortestDistance){
                        shortestDistance = dist;
                        target = enemy;
                    }
                    
                }
                if(shortestDistance > 0.6){
                    Debug.Log("There is no enemy at the target");
                    currentItem = null;
                    return;
                }

                Vector2 targetPos = target.transform.position;
                int[] targetGrid = PlayerInteraction.getItemGrid(targetPos.x,targetPos.y);
                int[] playerGrid = PlayerInteraction.getPlayerGrid();

                int range = 1;
                if(Equals(PlayerData.MeleeInventory.Peek().name,3)){
                    range = 2;
                }

                if(Mathf.Abs(targetGrid[0]-playerGrid[0])>range || Mathf.Abs(targetGrid[1]-playerGrid[1])>range){
                    Debug.Log("You can only attack within range tile");
                    currentItem = null;
                    return;
                }
                
                if(PlayerData.canAttack && PlayerData.MeleeInventory.Count>0){
                    Debug.Log("Hit");
                    PlayerData.canAttack = false;
                    Enemy e = (Enemy)Garden.tiles[targetGrid[0]][targetGrid[1]];
                    e.takeDamage(PlayerData.MeleeInventory.Peek().damage);
                    PlayerData.MeleeInventory.Peek().durability--;
                    if(PlayerData.MeleeInventory.Peek().durability<=0){
                        PlayerData.DequeueMelee();
                    }
                    Garden.reloadGarden();
                }
            }
            currentItem = null;
            
        }
        
    }
}
