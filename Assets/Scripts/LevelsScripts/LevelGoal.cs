using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    [HideInInspector]
    public LevelManager levelManager;
    public GoalScript[] goals;
    public float delayDuration;
    private float delayTimer=0;
    public float goalRequiredDuration;
    private float goalTimer=0;
    bool finished=false;
    void Update() {
        if(levelManager!=null && !finished){
            if(checkGoals() && goals.Length>0){
                if(goalTimer>=goalRequiredDuration){
                    StartCoroutine(finishLevel());
                    finished=true;
                }else goalTimer+=Time.deltaTime;
            }else goalTimer=0;
        }
    }
    IEnumerator finishLevel(){
        while(delayTimer<delayDuration){
            delayTimer+=Time.deltaTime;
            yield return null;
        }
        levelManager.finishLevel();
    }
    private bool checkGoals(){
        foreach(GoalScript goal in goals){
            if(!goal.active){
                return false;
            }
        }
        return true;
    }
}
