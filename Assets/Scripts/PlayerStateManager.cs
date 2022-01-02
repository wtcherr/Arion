using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerStatesNames{
    grounded,
    idle,
    walk,
    run,
    jump,
    doublejump,
    crouch,
    slide,
    airControl,
    flipDirection,
    meleeAttack,
    throwAttack,
    die
}
public enum stateStatus{
    notPresent,
    active,
    inactive
}
public class PlayerStateManager : MonoBehaviour
{
    public List<PlayerStateData> stateDatas=new List<PlayerStateData>();
    [HideInInspector]
    public Rigidbody2D rigidbody2D;
    [HideInInspector]
    public Animator animator;
    public Transform groundCheck;
    private Vector3 direction;
    private bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        rigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(PlayerStateData playerState in stateDatas){
            playerState.UpdateState(this, animator);
        }
    }
    public stateStatus checkStateStatus(PlayerStatesNames stateName){
        stateStatus status=stateStatus.notPresent;
        foreach(PlayerStateData state in stateDatas){
            if(state.stateName==stateName){
                status=state.isActive()?stateStatus.active:stateStatus.inactive;
            }
        }
        return status;
    }
    public void horizontalMove(Vector3 target,float speed){
        direction=target-this.transform.position;
        direction.Normalize();
        direction.z=0;
        direction.y=0;
        transform.position+=direction*speed*Time.deltaTime;
        flip();
    }
    private void flip(){
        if(Mathf.Abs(direction.x)>0){
            Vector3 scale=this.transform.localScale;
            if(isFacingRight){
                if((scale.x>0)!=(direction.x>0)){
                    scale.x*=-1;
                }
            }else{
                if((scale.x>0)==(direction.x>0)){
                    scale.x*=-1;
                }
            }
            this.transform.localScale=scale;
        }
    }
}
