using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerState_Jump : PlayerStateData
{
    public KeyCode jumpButton;
	public float speed;
	public float cooldownDuration=0.5f;
	private float timer=0;
	private bool jumped=false;
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
		}else{
			active=true;
		}
		if(jumped){
			if(timer<=cooldownDuration)timer+=Time.deltaTime;
			if(timer>cooldownDuration && jumped){
				jumped=false;
				timer=0;
			}
		}
	}
}
