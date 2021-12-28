using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerState_Idle : PlayerStateData
{
	public override void checkState(PlayerStateManager stateManager, Animator animator)
	{
        active=true;
	}
}
