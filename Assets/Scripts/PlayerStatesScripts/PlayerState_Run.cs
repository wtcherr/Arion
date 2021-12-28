using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerState_Run : PlayerStateData
{
    // Start is called before the first frame update
    public float speed;
    public KeyCode runButton;
    private Vector3 direction;
	public override void checkState(PlayerStateManager stateManager, Animator animator)
	{
		direction.x=Input.GetAxis("Horizontal");
        if(Input.GetKey(runButton)){
            stateManager.horizontalMove(stateManager.transform.position+direction,speed);
            active=true;
        }
	}
}
