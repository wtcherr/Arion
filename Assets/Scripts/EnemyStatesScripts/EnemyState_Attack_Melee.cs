using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Attack_Melee : EnemyStateData
{
    public float attackRange;
    public float damage=2;
    public Transform effectBox;
    public Transform target;
    public float cooldownDuration=5;
    private float cooldownTimer=0;
    public float activeDuration=1;
    private float activeTimer=0;
    private HealthScript myHealth;
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{
        if(myHealth!=null)myHealth=stateManager.GetComponent<HealthScript>();
		if(target==null)target=stateManager.target;
        if(checkTrigger(stateManager,animator)){
            if(cooldownTimer>=cooldownDuration){
                if(activeTimer<=activeDuration){
                    activeTimer+=Time.deltaTime;
                    checkHit();
                    active=true;
                }else{
                    cooldownTimer=0;
                    activeTimer=0;
                }
            }
        }
        if(cooldownTimer<cooldownDuration)cooldownTimer+=Time.deltaTime;
	}

	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
		if(target==null)target=stateManager.target;
        return horizontalDistance(stateManager.transform.position,target.position)<=attackRange;
	}

	private float horizontalDistance(Vector3 p1,Vector3 p2){
		return Mathf.Abs(p1.x-p2.x);
	}
    private bool checkHit(){
        ContactFilter2D filter2D=new ContactFilter2D();
        Collider2D[] hits=new Collider2D[10];
        effectBox.GetComponent<Collider2D>().OverlapCollider(filter2D.NoFilter(),hits);
        foreach(Collider2D other in hits){
            if(other==null)return false;
            HealthScript hs=other.GetComponent<HealthScript>();
            if(hs!=null){
                if(hs!=myHealth){
                    hs.takeDamage(damage);
                    return true;
                }
            }
        }
        return false;
    }
}
