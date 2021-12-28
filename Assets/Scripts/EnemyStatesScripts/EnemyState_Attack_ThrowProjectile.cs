using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attack_ThrowProjectile : EnemyStateData
{
    public Transform firePoint;
    public Transform target;
    public GameObject projectile;
    public float attackRange;
    public float cooldownDuration;
    private float cooldownTimer=0;
    private Vector3 direction;
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{
        if(checkTrigger(stateManager,animator)){
            if(cooldownTimer>=cooldownDuration){
                direction=target.position-firePoint.position;
                direction.Normalize();
                fire(direction);
                cooldownTimer=0;
            }else{
                cooldownTimer+=Time.deltaTime;
            }
            active=true;
        }

	}

	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
        if(horizontalDistance(stateManager.transform.position,target.position)<=attackRange){
            return true;
        }else return false;
	}

	private void fire(Vector3 direction){
        GameObject go=Instantiate(projectile);
        go.transform.position=firePoint.position;
        go.GetComponent<ProjectileController>().shoot(direction,target);
    }
    private float horizontalDistance(Vector3 p1,Vector3 p2){
        return Mathf.Abs(p1.x-p2.x);
    }
}
