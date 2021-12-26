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
}
