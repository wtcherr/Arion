using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attack_Rush : EnemyStateData
{
    private Transform target;
    public float speed;
    public float damage;
    public Transform hitBox;
    public float attackRange;
    public float minDistance;
    public float cooldownDuration;
    private float cooldownTimer=0;
    private EnemyStateManager stateManager;
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{   
        target=stateManager.target; 
        this.stateManager=stateManager;
        if(checkTrigger(stateManager,animator)){
            if(cooldownTimer>=cooldownDuration){
                StartCoroutine(rush(target.position,speed));
                cooldownTimer=0;
            }else cooldownTimer+=Time.deltaTime;
            active=true;
        }
	}
	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
        target=stateManager.target;
        if(horizontalDistance(target.position,stateManager.transform.position)<attackRange){
            return true;
        }else return false;
	}
    private IEnumerator rush(Vector3 target,float speed){
        bool damaged=false;
        while(horizontalDistance(stateManager.transform.position,target)>minDistance){
            stateManager.move(target,speed);
            if(!damaged){
                if(checkHit())damaged=true;
            }
            yield return null;
        }
    }
    private float horizontalDistance(Vector3 p1,Vector3 p2){
        return Mathf.Abs(p1.x-p2.x);
    }
    private bool checkHit(){
        ContactFilter2D filter2D=new ContactFilter2D();
        Collider2D[] hits=new Collider2D[10];
        hitBox.GetComponent<Collider2D>().OverlapCollider(filter2D.NoFilter(),hits);
        foreach(Collider2D other in hits){
            if(other==null)return false;
            HealthScript hs=other.GetComponent<HealthScript>();
            if(hs!=null){
                hs.takeDamage(damage);
                return true;
            }
        }
        return false;
    }
}
