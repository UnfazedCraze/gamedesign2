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

                if(Mathf.Abs(targetGrid[0]-playerGrid[0])>1 || Mathf.Abs(targetGrid[1]-playerGrid[1])>1){
                    Debug.Log("You can only attack within range 1 tile");
                    currentItem = null;
                    return;
                }
                
                if(PlayerData.canAttack && PlayerData.MeleeInventory.Count>0){
                    Debug.Log("Hit");
                    PlayerData.canAttack = false;
                    target.GetComponent<Enemy>().takeDamage(PlayerData.MeleeInventory[0].damage);
                    if(target.GetComponent<Enemy>().HP <= 0){
                        GameObject.Destroy(target);
                    }
                    PlayerData.MeleeInventory[0].durability--;
                    if(PlayerData.MeleeInventory[0].durability==0){
                        PlayerData.MeleeInventory.RemoveAt(0);
                    }
                }
            }
            currentItem = null;
            
        }
        
    }
}
