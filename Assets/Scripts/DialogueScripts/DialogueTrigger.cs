using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] sentences;
    public KeyCode displayBtn;
    public GameObject hintPanel;
    public TextMeshProUGUI hintText;
    public DialogueManager dialogueManager;
    public GameObject player;
    void Start() {
        if(player==null)GameObject.FindWithTag("Player");
        displayBtn=KeyCode.E;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform==player.transform){
            hintText.text=displayBtn.ToString();
            hintPanel.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.transform==player.transform){
            hintPanel.SetActive(false);
        }
        dialogueManager.stopDisplay();
    }
    void OnTriggerStay2D(Collider2D other) {
        if(other.transform==player.transform){
            if(Input.GetKey(displayBtn)){
                hintPanel.SetActive(false);
                startDisplay();
            }
        }   
    }
    public void startDisplay(){
        dialogueManager.setSentences(sentences);
        StartCoroutine(dialogueManager.TypeDialogue());
    }
}
