using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_DoubleJump : PlayerStateData
{
    public KeyCode jumpButton;
    public float speed;
	private bool jumped=false;
	private bool doubleJumped=false;
	public float firstJumpDelay;
	private float firstJumpTimer=0;
	public float secondJumpDelay;
	private float secondJumpTimer=0;
	public override void checkState(PlayerStateManager stateManager, Animator animator)
	{
		stateStatus groundedStatus=stateManager.checkStateStatus(PlayerStatesNames.grounded);
		if(groundedStatus==stateStatus.active || groundedStatus==stateStatus.notPresent){
			if(Input.GetKey(jumpButton)){
				if(!jumped){
					stateManager.rigidbody2D.velocity+=new Vector2(0,speed);
					jumped=true;
				}
			}
			doubleJumped=false;
			secondJumpTimer=secondJumpDelay;
		}else{
			active=true;
			secondJumpTimer=Mathf.Max(0,secondJumpTimer-Time.deltaTime);
			if(Input.GetKey(jumpButton) && !doubleJumped && secondJumpTimer==0){
				stateManager.rigidbody2D.velocity+=new Vector2(0,speed);
				doubleJumped=true;
			}
		}
		if(jumped){
			if(firstJumpTimer<=firstJumpDelay){
				firstJumpTimer+=Time.deltaTime;
			}else{
				firstJumpTimer=0;
				jumped=false;
			}
		}
	}
}
