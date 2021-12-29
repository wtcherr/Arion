using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyState_Idle : EnemyStateData
{
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{
		List<EnemyStateData> currentStates=stateManager.getCurrentStates();
		bool ok=true;
		foreach(EnemyStateData state in currentStates){
			if(state.stateName!=EnemyStatesNames.idle){
				ok=false;
			}
		}
		if(ok)
			active=true;
		else active=false;
	}

	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
		return true;
	}
}
