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
                    if(Equals(PlayerData.PotionInventory.Peek().name,"2")){
                        PlayerData.HP += 5;
                        PlayerData.PotionInventory.Dequeue();
                        return;
                    }

                    Debug.Log("Boom");
                    PlayerData.canUseItem = false;
                    List<Enemy> enemies = new List<Enemy>();

                    for(int i = 0; i < Garden.tiles.Length; i++){
                        for(int j = 0; j < Garden.tiles[i].Length; j++){
                            if(Garden.tiles[i][j]!=null && Garden.tiles[i][j] is Enemy){
                                Enemy e = (Enemy)Garden.tiles[i][j];
                                if(Mathf.Abs(targetGrid[0]-i)+Mathf.Abs(targetGrid[1]-j)<=1){
                                    e.takeDamage(PlayerData.PotionInventory.Peek().damage);
                                }
                                if(Equals(PlayerData.PotionInventory.Peek().name,"3")){
                                    e.isFrozen = true;
                                }
                            }
                        }
                    }


                    // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
                    // foreach(GameObject enemy in enemies){
                    //     // Debug.Log(worldPos+"     "+enemy.transform.position);
                    //     int[] monsterGrid = PlayerInteraction.getItemGrid(enemy.transform.position.x,enemy.transform.position.y);
                    //     if(Mathf.Abs(targetGrid[0]-monsterGrid[0])+Mathf.Abs(targetGrid[1]-monsterGrid[1])<=1){
                    //         enemy.GetComponent<Enemy>().takeDamage(PlayerData.PotionInventory.Peek().damage);
                    //         if(enemy.GetComponent<Enemy>().HP <= 0){
                    //             GameObject.Destroy(enemy);
                    //         }
                    //     }
                        
                    // }
                    PlayerData.PotionInventory.Dequeue();
                    Garden.reloadGarden();
                }

            }
            currentItem = null;
            
        }
        
    }
}
