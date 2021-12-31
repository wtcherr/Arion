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
    [HideInInspector]
    public Transform player;
    void Start()
    {
        toggle1.player=player;
        toggle2.player=player;
    }
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
}
