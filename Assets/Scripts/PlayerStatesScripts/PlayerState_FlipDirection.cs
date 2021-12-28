using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerState_FlipDirection : PlayerStateData
{
    private Vector2 direction;
	public override void checkState(PlayerStateManager stateManager,Animator animator){
		direction.x=Input.GetAxis("Horizontal");
        if(Mathf.Abs(direction.x)>0){
            Vector3 scale=stateManager.transform.localScale;
            if((scale.x>0) ^ (direction.x>0)){
                scale.x*=-1;
            }
            stateManager.transform.localScale=scale;
        }
	}
}
