using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerState_DoubleJump",menuName ="PlayerStates/DoubleJump")]
public class PlayerState_DoubleJump : PlayerStateData
{
    public KeyCode jumpButton;
    public float jumpForce;
	private bool doubleJumped=false;
	public float secondJumpDelay;
	private float secondJumpTimer=0;
	public override void checkState(PlayerStateManager stateManager, Animator animator)
	{
		stateStatus groundedStatus=stateManager.checkStateStatus(PlayerStatesNames.grounded);
		if(groundedStatus==stateStatus.active || groundedStatus==stateStatus.notPresent){
			if(Input.GetKey(jumpButton)){
				stateManager.rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
			}
			doubleJumped=false;
			secondJumpTimer=secondJumpDelay;
		}else{
			active=true;
			secondJumpTimer=Mathf.Max(0,secondJumpTimer-Time.deltaTime);
			if(Input.GetKey(jumpButton) && !doubleJumped && secondJumpTimer==0){
				stateManager.rigidbody2D.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
				doubleJumped=true;
			}
		}
	}
}
