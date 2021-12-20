using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerState_Jump", menuName = "PlayerStates/Jump")]
public class PlayerState_Jump : PlayerStateData
{
    public KeyCode jumpButton;
    public float jumpForce;
	public override void checkState(PlayerStateManager stateManager, Animator animator)
	{
		stateStatus groundedStatus=stateManager.checkStateStatus(PlayerStatesNames.grounded);
		if(groundedStatus==stateStatus.active || groundedStatus==stateStatus.notPresent){
			if(Input.GetKey(jumpButton)){
				stateManager.rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
			}
		}else{
			active=true;
		}
	}
}
