using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerState_Walk : PlayerStateData
{
    public float speed;
    private Vector3 direction;
    // Start is called before the first frame update
    public override void checkState(PlayerStateManager stateManager,Animator animator){
        direction.x=Input.GetAxis("Horizontal");
        stateManager.horizontalMove(stateManager.transform.position+direction,speed);
        active=Mathf.Abs(direction.x)>0;
    }
}
