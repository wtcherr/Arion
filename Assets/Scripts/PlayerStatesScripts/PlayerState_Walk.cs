using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerState_Walk",menuName ="PlayerStates/Walk")]
public class PlayerState_Walk : PlayerStateData
{
    public float speed;
    private Vector2 direction;
    // Start is called before the first frame update
    public override void checkState(PlayerStateManager stateManager,Animator animator){
        direction.x=Input.GetAxis("Horizontal");
        stateManager.rigidbody2D.velocity=direction*speed;
        active=Mathf.Abs(direction.x)>0;
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
