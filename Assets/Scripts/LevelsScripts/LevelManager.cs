using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform target;
    [HideInInspector]
    public FrameManager[] frames;
    [HideInInspector]
    public Transform lastCheckPoint;
    public int nextSceneBuildIndex;
    public int gameOverSceneBuildIndex;
    private HealthScript playerHealth;
    public NavigationController navigationController;
    private int lives;
    void Awake() {
        frames=GetComponentsInChildren<FrameManager>();
        if(target==null)target=GameObject.FindWithTag("Player").transform;
        playerHealth=target.GetComponent<HealthScript>();
        GetComponentInChildren<LevelGoal>().levelManager=this;
        activateAllFrames();
        assignFramesTarget();
        assignFrameSwitches();
        deactivateAllFrames();
        frames[0].gameObject.SetActive(true);
    }
    void Start()
    {
        if(navigationController==null)navigationController=GameObject.FindObjectOfType<NavigationController>();
        lives=playerHealth.lives;
    }
    void Update() {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
    public void respawn(){
        target.position=lastCheckPoint.transform.position;
    }
    public void gameOver(){
        Destroy(target.gameObject);
        navigationController.GoToScene(gameOverSceneBuildIndex);
    }
    public void finishLevel(){
        navigationController.GoToScene(nextSceneBuildIndex);
    }
    void activateAllFrames(){
        foreach(FrameManager frame in frames){
            frame.gameObject.SetActive(true);
        }
    }
    void deactivateAllFrames(){
        foreach(FrameManager frame in frames){
            frame.gameObject.SetActive(false);
        }
    }
}
