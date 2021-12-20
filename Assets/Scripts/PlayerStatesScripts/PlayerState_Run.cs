using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_Run",menuName ="PlayerStates/Run")]
public class PlayerState_Run : PlayerStateData
{
    // Start is called before the first frame update
    public float speed;
    public KeyCode runButton;
    private Vector2 direction;
	public override void checkState(PlayerStateManager stateManager, Animator animator)
	{
		direction.x=Input.GetAxis("Horizontal");
        if(Input.GetKey(runButton)){
            stateManager.rigidbody2D.velocity=direction*speed;
            active=true;
        }
        //checkFlip(stateManager);
	}

    public void checkFlip(PlayerStateManager stateManager){
        if(Mathf.Abs(direction.x)>0){
            Vector3 scale=stateManager.transform.localScale;
            if((scale.x>0) ^ (direction.x>0)){
                scale.x*=-1;
            }
            stateManager.transform.localScale=scale;
        }
    }
}
