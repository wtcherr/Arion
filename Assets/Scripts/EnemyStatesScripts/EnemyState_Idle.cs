using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyState_Idle : EnemyStateData
{
	public override void checkState(EnemyStateManager stateManager, Animator animator)
	{
		active=true;
	}

	public override bool checkTrigger(EnemyStateManager stateManager, Animator animator)
	{
		return true;
	}
}
