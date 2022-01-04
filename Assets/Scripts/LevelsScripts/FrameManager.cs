using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameManager : MonoBehaviour
{
    [HideInInspector]
    public LevelManager levelManager;
    [HideInInspector]
    public CheckPoint checkPoint;
    [HideInInspector]
    public Cinemachine.CinemachineVirtualCamera vcam;
    [HideInInspector]
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        levelManager=GetComponentInParent<LevelManager>();
        vcam=GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();
        checkPoint=GetComponentInChildren<CheckPoint>();
        levelManager.lastCheckPoint=checkPoint.transform;
        assignEnemiesTarget();
        vcam.Follow=target;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void assignEnemiesTarget(){
        EnemyStateManager[] enemies=GetComponentsInChildren<EnemyStateManager>();
        foreach(EnemyStateManager enemy in enemies){
            enemy.target=target;
        }
    }
    public void setActiveCheckPoint(CheckPoint checkPoint){
        levelManager.lastCheckPoint=checkPoint.transform;
    }
}
