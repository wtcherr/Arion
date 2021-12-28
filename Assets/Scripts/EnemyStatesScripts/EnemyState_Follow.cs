using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Follow : EnemyStateData
{
    public float speed=0;
    public float followRange=0;
    private Transform target;
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{
		target=stateManager.target;
		if(horizontalDistance(stateManager.transform.position,target.position)<=followRange){
            stateManager.move(target.position,speed);
            active=true;
        }
	}

	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
		target=stateManager.target;
		if(horizontalDistance(stateManager.transform.position,target.position)<=followRange){
			return true;
		}else return false;
	}

	private float horizontalDistance(Vector3 p1,Vector3 p2){
		return Mathf.Abs(p1.x-p2.x);
	}
}
