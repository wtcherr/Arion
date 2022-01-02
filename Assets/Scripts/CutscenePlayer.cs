using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayer : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer[] videoPlayers;
    bool playing=false;
    int index=0;
    public NavigationController navigationController;
    public int nextScene=0;
    public KeyCode skipBtn;
    float timer=0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(UnityEngine.Video.VideoPlayer video in videoPlayers){
            video.playOnAwake=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(index<videoPlayers.Length &&!playing){
            videoPlayers[index].Play();
        }
        if(timer<videoPlayers[index].length){
            timer+=Time.deltaTime;
            playing=true;
        }else {
            playing=false;
            timer=0;
        }
        if(!playing)index++;
        if(index>=videoPlayers.Length)navigationController.GoToScene(nextScene);
        if(Input.GetKeyDown(skipBtn)){
            navigationController.GoToScene(nextScene);
        }
    }
}
