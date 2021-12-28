using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState_Die : EnemyStateData
{
    private HealthScript hs;
    public float deathDuration=10f;
    public float deathTimer=0;
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{
        hs=stateManager.gameObject.GetComponent<HealthScript>();
        if(hs.checkHealthStates()==HealthStates.dead){
            active=true;
            if(deathTimer>=deathDuration){
                Destroy(stateManager.transform.parent.gameObject);
            }else deathTimer+=Time.deltaTime;
        }
	}

	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
        return stateManager.GetComponent<HealthScript>().checkHealthStates()==HealthStates.dead;
	}
}
