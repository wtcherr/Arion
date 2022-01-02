using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Stomp : EnemyStateData
{
    public Transform hitBox;
    private HealthScript myHealth;
    private EnemyStateManager stateManager;
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{
        if(this.stateManager==null)this.stateManager=stateManager;
		if(myHealth==null)myHealth=stateManager.GetComponent<HealthScript>();
        if(checkTrigger(stateManager,animator)){
            myHealth.takeDamage(myHealth.maxHealth);
            active=true;
        }
	}

	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
        if(this.stateManager==null)this.stateManager=stateManager;
		if(myHealth==null)myHealth=stateManager.GetComponent<HealthScript>();
        return checkHit();
	}

    private bool checkHit(){
        ContactFilter2D filter2D=new ContactFilter2D();
        Collider2D[] hits=new Collider2D[10];
        hitBox.GetComponent<Collider2D>().OverlapCollider(filter2D.NoFilter(),hits);
        foreach(Collider2D other in hits){
            if(other==null)return false;
            if(other.transform==stateManager.target){
                return true;
            }
        }
        return false;
    }
}
