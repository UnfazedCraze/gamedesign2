using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public GameObject continueButton;
    public GameObject dialogueBox;

    public void StartDialogue(Dialogue dialogue){
        nameText.text = dialogue.name;
        continueButton.SetActive(true);
        dialogueBox.SetActive(true);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        
    }

    public void EndDialogue(){
        continueButton.SetActive(false);
        dialogueBox.SetActive(false);
        Debug.Log("End of conversation.");
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        continueButton.SetActive(false);
        dialogueBox.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
