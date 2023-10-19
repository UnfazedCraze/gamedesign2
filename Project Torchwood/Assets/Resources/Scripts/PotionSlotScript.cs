using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionSlotScript : MonoBehaviour
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
                int[] targetGrid = PlayerInteraction.getItemGrid(worldPos.x,worldPos.y);
                int[] playerGrid = PlayerInteraction.getPlayerGrid();
                if(Mathf.Abs(targetGrid[0]-playerGrid[0])>2 || Mathf.Abs(targetGrid[1]-playerGrid[1])>2){
                    Debug.Log("You can only use potion within range 2 tile");
                    return;
                }

                if(PlayerData.canUseItem && PlayerData.PotionInventory.Count>0){
                    Debug.Log("Boom");
                    PlayerData.canUseItem = false;
                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
                    foreach(GameObject enemy in enemies){
                        // Debug.Log(worldPos+"     "+enemy.transform.position);
                        int[] monsterGrid = PlayerInteraction.getItemGrid(enemy.transform.position.x,enemy.transform.position.y);
                        if(Mathf.Abs(targetGrid[0]-monsterGrid[0])+Mathf.Abs(targetGrid[1]-monsterGrid[1])<=1){
                            enemy.GetComponent<Enemy>().takeDamage(PlayerData.PotionInventory[0].damage);
                            if(enemy.GetComponent<Enemy>().HP <= 0){
                                GameObject.Destroy(enemy);
                            }
                        }
                        
                    }
                    PlayerData.PotionInventory.RemoveAt(0);
                }

            }
            currentItem = null;
            
        }
        
    }
}
