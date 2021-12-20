using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_AirControl",menuName ="PlayerStates/AirControl")]
public class PlayerState_AirControl : PlayerStateData
{
    public float speed;
    private Vector2 direction;
	public override void checkState(PlayerStateManager stateManager, Animator animator)
	{
		direction.x=Input.GetAxis("Horizontal");
        direction.y=Input.GetAxis("Vertical");
        direction.y=Mathf.Min(direction.y,0);
        stateManager.rigidbody2D.position+=direction*speed*Time.deltaTime;
	}
}
