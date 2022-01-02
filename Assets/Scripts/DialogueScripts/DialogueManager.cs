using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] dialogueSentences;
    private int index=0;
    public float typingSpeed;
    public GameObject okayButton;
    public GameObject dialogueBox;
    public GameObject player;
    void Start(){
        dialogueBox.SetActive(false);
        okayButton.SetActive(false);
        dialogueSentences=null;
    }
    public IEnumerator TypeDialogue(){
        dialogueBox.SetActive(true);
        textDisplay.text="";
        for(int letter=0;letter<dialogueSentences[index].Length;letter++){
            textDisplay.text+=dialogueSentences[index][letter];
            yield return new WaitForSeconds(typingSpeed);
        }
        okayButton.SetActive(true);
    }
    public void NextSentence(){
        okayButton.SetActive(false);
        if(index<dialogueSentences.Length-1){
            index++;
            textDisplay.text="";
            StartCoroutine(TypeDialogue());
        }else{
            textDisplay.text="";
            okayButton.SetActive(false);
            dialogueBox.SetActive(false);
            this.dialogueSentences=null;
            index=0;
            //TODO Unfreeze the player
        }
    }
    public void setSentences(string[] sentences){
        dialogueSentences=sentences;
    }
    public void stopDisplay(){
        dialogueSentences=null;
        dialogueBox.SetActive(false);
        okayButton.SetActive(false);
    }
}
