using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform target;
    //[HideInInspector]
    public FrameManager[] frames;
    public Transform lastCheckPoint;
    private HealthScript playerHealth;
    private int lives;
    void Awake() {
        frames=GetComponentsInChildren<FrameManager>();
        if(target==null)target=GameObject.FindWithTag("Player").transform;
        playerHealth=target.GetComponent<HealthScript>();
        assignFramesTarget();
        /*assignCamerasTarget();
        assignFrameSwitches();
        assignCheckPointsLevelManager();*/
    }
    void Start()
    {
        lives=playerHealth.lives;
    }
    void Update() {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(lastCheckPoint.position,target.position-lastCheckPoint.position,Color.cyan);
        checkTargetHealth();
    }
    void assignFramesTarget(){
        foreach(FrameManager frame in frames){
            frame.target=target;
        }
    }
    void assignFrameSwitches(){
        FrameSwitch[] frameSwitches=GetComponentsInChildren<FrameSwitch>();
        foreach(FrameSwitch frameSwitch in frameSwitches){
            frameSwitch.player=target;
        }
    }
    void checkTargetHealth(){
        if(playerHealth.lives<lives){
            if(playerHealth.lives==0){
                gameOver();
            }
            respawn();
            lives=playerHealth.lives;
        }
    }
    void respawn(){
        target.position=lastCheckPoint.transform.position;
    }
    void gameOver(){
        Destroy(target.gameObject);
        Destroy(this.gameObject);
    }
}
