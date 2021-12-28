using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyStatesNames{
    idle,
    patrol,
    follow,
    attack,
    die
}
public class EnemyStateManager : MonoBehaviour
{
    public bool isFacingRight=true;
    public List<EnemyStateData> cycleStates=new List<EnemyStateData>();
    public List<EnemyStateData> triggerStates=new List<EnemyStateData>();
    [HideInInspector]
    public Animator animator;
    public Transform target;
    private List<EnemyStateData> currentStates=new List<EnemyStateData>();
    private Vector3 direction;
    private int index=0;
    // Start is called before the first frame update
    void Start()
    {
        currentStates=new List<EnemyStateData>();
        animator=GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        currentStates=new List<EnemyStateData>();
        UpdateTriggerStates();
        if(currentStates.Count==0)UpdateCycleStates();
        UpdateCurrentStates();
    }
    void UpdateCycleStates(){
        if(index<cycleStates.Count){
            if(!cycleStates[index].isActive()){
                index++;
                index%=cycleStates.Count;
                cycleStates[index].reset();
            }
            addState(cycleStates[index]);
        }
    }
    void UpdateTriggerStates(){
        int maxPriority=-100000;
        foreach(EnemyStateData enemyState in triggerStates){
            if(enemyState.checkTrigger(this,animator)){
                maxPriority=Mathf.Max(maxPriority,enemyState.priority);
            }
        }
        foreach(EnemyStateData enemyState in triggerStates){
            if(enemyState.priority==maxPriority){
                addState(enemyState);
            }
        }
    }
    void UpdateCurrentStates(){
        foreach(EnemyStateData enemyState in currentStates){
            enemyState.UpdateState(this,animator);
        }
    }
    public void addState(EnemyStateData newState){
        foreach(EnemyStateData enemyState in currentStates){
            if(enemyState.stateName==EnemyStatesNames.die)return;
        }
        currentStates.Add(newState);
    }
    public void move(Vector3 target,float speed){
        direction=target-this.transform.position;
        direction.Normalize();
        direction.z=0;
        direction.y=0;
        transform.position+=direction*speed*Time.deltaTime;
        flip();
    }
    private void flip(){
        if(Mathf.Abs(direction.x)>0){
            Vector3 scale=this.transform.localScale;
            if(isFacingRight){
                if((scale.x>0)!=(direction.x>0)){
                    scale.x*=-1;
                }
            }else{
                if((scale.x>0)==(direction.x>0)){
                    scale.x*=-1;
                }
            }
            this.transform.localScale=scale;
        }
    }
}
