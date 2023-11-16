using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public int dialogueID;

    public void TriggerDialogue(){
        if(PlayerData.currentDialogueCount != dialogueID){
            return;
        }
        PlayerData.currentDialogueCount++;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
