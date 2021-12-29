using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstFrame;
    public GameObject secondFrame;
    public FrameSwitchToggle toggle1;
    public FrameSwitchToggle toggle2;
    public Transform player;
    void Start()
    {
        toggle1.player=player;
        toggle2.player=player;
    }

    // Update is called once per frame
    void Update()
    {
        if(toggle1.active && toggle2.active){
            firstFrame.SetActive(true);
            secondFrame.SetActive(true);
        }else if(toggle1.active){
            firstFrame.SetActive(true);
            secondFrame.SetActive(false);
        }else if(toggle2.active){
            firstFrame.SetActive(false);
            secondFrame.SetActive(true);
        }
    }

    /*void OnTriggerEnter2D(Collider2D other) {
        if(other.transform==player.transform){
            firstFrame.SetActive(true);
            secondFrame.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.transform!=player.transform){
            if(distance(firstFrame.transform,other.transform)<distance(secondFrame.transform,other.transform)){
                other.transform.parent=firstFrame.transform;
            }else{
                other.transform.parent=secondFrame.transform;
            }
        }
        if(other.transform==player.transform){
            if(distance(firstFrame.transform,player)<distance(secondFrame.transform,player)){
                firstFrame.SetActive(true);
                secondFrame.SetActive(false);
            }else{
                firstFrame.SetActive(false);
                secondFrame.SetActive(true);
            }
        }
    }
    float distance(Transform p1,Transform p2){
        return Vector3.Distance(p1.position,p2.position);
    }*/
}