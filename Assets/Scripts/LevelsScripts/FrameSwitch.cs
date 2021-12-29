using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstFrame;
    public GameObject secondFrame;
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other) {
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
    }
}
