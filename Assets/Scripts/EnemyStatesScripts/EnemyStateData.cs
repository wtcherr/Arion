using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStateData : MonoBehaviour
{
	protected bool active;
	public float duration=100000;
	private float timer=0;
	public EnemyStatesNames stateName;
	public string animationVariableName;
	public bool animationVariableValue;
	public int priority;
	public void UpdateState(EnemyStateManager stateManager,Animator animator){
		if(timer<duration){
			active=false;
			checkState(stateManager,animator);
			timer+=Time.deltaTime;
		}else active=false;
        if(animationVariableName!=""){
            if(active)setAnimator(animator,animationVariableName,animationVariableValue);
            else setAnimator(animator,animationVariableName,!animationVariableValue);
        }
	}
	public abstract void checkState(EnemyStateManager stateManager,Animator animator);
	public abstract bool checkTrigger(EnemyStateManager stateManager,Animator animator);
	public bool isActive(){
		return active;
	}
	public void reset(){
		timer=0;
	}
    public void setAnimator(Animator animator,string animationVariableName,bool animationVariableValue){
        animator.SetBool(animationVariableName,animationVariableValue);
    }
}
