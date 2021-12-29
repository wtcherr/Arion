using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    public LevelManager levelManager;
    void OnTriggerEnter2D(Collider2D other) {
        if(levelManager!=null){
            levelManager.finishLevel();
        }
    }
}
