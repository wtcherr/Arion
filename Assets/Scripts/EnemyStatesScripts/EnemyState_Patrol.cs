using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyState_Patrol : EnemyStateData
{
    public List<Transform> points=new List<Transform>();
	public float minDistance=0.5f;
	public float speed=0f;
	private Vector3 currentPoint;
	private int pointIndex=0;
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{
		if(pointIndex<points.Count){
			currentPoint=points[pointIndex].position;
			if(horizontalDistance(currentPoint,stateManager.transform.position)<=minDistance)nextPoint();
			else{
				stateManager.move(currentPoint,speed);
			}
			active=true;
		}
	}
	private void nextPoint(){
		pointIndex++;
		pointIndex%=points.Count;
	}
	private float horizontalDistance(Vector3 p1,Vector3 p2){
		return Mathf.Abs(p1.x-p2.x);
	}

	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
		return true;
	}
}
